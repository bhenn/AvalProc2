Imports System.Data.Entity

<Authorize>
Public Class UsuarioController
    Inherits System.Web.Mvc.Controller

    Private db As New AvalProcContexto


    <HttpGet>
    <AllowAnonymous>
    Function Login() As ActionResult
        Return View()
    End Function

    <HttpPost()> _
    <AllowAnonymous>
    Public Function Login(ByVal usuario As Usuario, ByVal returnUrl As String) As ActionResult

        If ModelState.IsValid Then
            If isValid(usuario.Email, usuario.Senha) Then
                FormsAuthentication.SetAuthCookie(usuario.Email, False)
                Return RedirectLogin(returnUrl)

                'Return RedirectToAction("Index", "Home")
            Else
                ModelState.AddModelError("", "Dados do login estão incorretos")
            End If
        End If

        Return View()
    End Function

    <AllowAnonymous>
    Function Logout() As ActionResult

        FormsAuthentication.SignOut()

        Return RedirectToAction("Index", "Home")
    End Function


    '
    ' GET: /Usuario/

    Function Index() As ActionResult
        Return View(db.Usuarios.ToList())
    End Function

    '
    ' GET: /Usuario/Create
    <AllowAnonymous>
    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Usuario/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    <AllowAnonymous>
    Function Create(ByVal usuario As Usuario) As ActionResult
        If ModelState.IsValid Then
            Dim crypto As New SimpleCrypto.PBKDF2
            usuario.Senha = crypto.Compute(usuario.Senha)
            usuario.SenhaSalt = crypto.Salt

            db.Usuarios.Add(usuario)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(usuario)
    End Function

    '
    ' GET: /Usuario/Delete/5

    Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim usuario As Usuario = db.Usuarios.Find(id)
        If IsNothing(usuario) Then
            Return HttpNotFound()
        End If
        Return View(usuario)
    End Function

    '
    ' POST: /Usuario/Delete/5

    <HttpPost()> _
    <ActionName("Delete")> _
    <ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
        Dim usuario As Usuario = db.Usuarios.Find(id)
        db.Usuarios.Remove(usuario)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

    Function isValid(email As String, senha As String) As Boolean
        Dim valido As Boolean = False
        Dim crypto As New SimpleCrypto.PBKDF2

        Dim oUsario As Usuario

        oUsario = db.Usuarios.FirstOrDefault(Function(x) x.Email = email)


        If Not IsNothing(oUsario) Then
            If oUsario.Senha = crypto.Compute(senha, oUsario.SenhaSalt) Then
                valido = True
            End If
        End If


        Return valido
    End Function


    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

#Region "Helpers"
    Private Function RedirectLogin(ByVal returnUrl As String) As ActionResult
        If Url.IsLocalUrl(returnUrl) Then
            Return Redirect(returnUrl)
        Else
            Return RedirectToAction("Index", "Home")
        End If
    End Function
#End Region

End Class