Imports System.Data.Entity

Public Class PaController
    Inherits System.Web.Mvc.Controller

    Private db As New AvalProcContexto

    '
    ' GET: /Pa/

    Function Index() As ActionResult
        Return View(db.Pas.ToList())
    End Function

    '
    ' GET: /Pa/Details/5

    Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim pa As Pa = db.Pas.Find(id)
        If IsNothing(pa) Then
            Return HttpNotFound()
        End If
        Return View(pa)
    End Function

    '
    ' GET: /Pa/Create

    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Pa/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal pa As Pa) As ActionResult
        If ModelState.IsValid Then
            db.Pas.Add(pa)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(pa)
    End Function

    '
    ' GET: /Pa/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim pa As Pa = db.Pas.Find(id)
        If IsNothing(pa) Then
            Return HttpNotFound()
        End If
        Return View(pa)
    End Function

    '
    ' POST: /Pa/Edit/5

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal pa As Pa) As ActionResult
        If ModelState.IsValid Then
            db.Entry(pa).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(pa)
    End Function

    '
    ' GET: /Pa/Delete/5

    Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim pa As Pa = db.Pas.Find(id)
        If IsNothing(pa) Then
            Return HttpNotFound()
        End If
        Return View(pa)
    End Function

    '
    ' POST: /Pa/Delete/5

    <HttpPost()> _
    <ActionName("Delete")> _
    <ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
        Dim pa As Pa = db.Pas.Find(id)
        db.Pas.Remove(pa)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class