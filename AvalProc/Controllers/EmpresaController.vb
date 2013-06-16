Imports System.Data.Entity

<Authorize>
Public Class EmpresaController
    Inherits System.Web.Mvc.Controller

    Private db As New AvalProcContexto

    '
    ' GET: /Empresa/

    Function Index() As ActionResult
        Return View()
    End Function

    Function List() As ActionResult
        Return PartialView(db.Empresas.ToList())
    End Function

    '
    ' GET: /Empresa/Create

    Function Create() As ActionResult
        Return PartialView()
    End Function

    '
    ' POST: /Empresa/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal empresa As Empresa) As ActionResult
        If ModelState.IsValid Then
            db.Empresas.Add(empresa)
            db.SaveChanges()
            Return RedirectToAction("List")
        End If

        Return PartialView(empresa)
    End Function

    '
    ' GET: /Empresa/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim empresa As Empresa = db.Empresas.Find(id)
        If IsNothing(empresa) Then
            Return HttpNotFound()
        End If
        Return PartialView(empresa)
    End Function

    '
    ' POST: /Empresa/Edit/5

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal empresa As Empresa) As ActionResult
        If ModelState.IsValid Then
            db.Entry(empresa).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("List")
        End If

        Return PartialView(empresa)
    End Function

    '
    ' POST: /Empresa/Delete/5

    <HttpPost()> _
    Function Delete(ByVal id As Integer) As RedirectToRouteResult
        Dim empresa As Empresa = db.Empresas.Find(id)
        db.Empresas.Remove(empresa)
        db.SaveChanges()
        Return RedirectToAction("List")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class