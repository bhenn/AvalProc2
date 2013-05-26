Imports System.Data.Entity

Public Class EmpresaController
    Inherits System.Web.Mvc.Controller

    Private db As New AvalProcContexto

    '
    ' GET: /Empresa/

    Function Index() As ActionResult
        Return View(db.Empresas.ToList())
    End Function

    '
    ' GET: /Empresa/Details/5

    Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim empresa As Empresa = db.Empresas.Find(id)
        If IsNothing(empresa) Then
            Return HttpNotFound()
        End If
        Return View(empresa)
    End Function

    '
    ' GET: /Empresa/Create

    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Empresa/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal empresa As Empresa) As ActionResult
        If ModelState.IsValid Then
            db.Empresas.Add(empresa)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(empresa)
    End Function

    '
    ' GET: /Empresa/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim empresa As Empresa = db.Empresas.Find(id)
        If IsNothing(empresa) Then
            Return HttpNotFound()
        End If
        Return View(empresa)
    End Function

    '
    ' POST: /Empresa/Edit/5

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal empresa As Empresa) As ActionResult
        If ModelState.IsValid Then
            db.Entry(empresa).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(empresa)
    End Function

    '
    ' GET: /Empresa/Delete/5

    Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim empresa As Empresa = db.Empresas.Find(id)
        If IsNothing(empresa) Then
            Return HttpNotFound()
        End If
        Return View(empresa)
    End Function

    '
    ' POST: /Empresa/Delete/5

    <HttpPost()> _
    <ActionName("Delete")> _
    <ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
        Dim empresa As Empresa = db.Empresas.Find(id)
        db.Empresas.Remove(empresa)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class