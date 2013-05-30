Imports System.Data.Entity

Public Class MpController
    Inherits System.Web.Mvc.Controller

    Private db As New AvalProcContexto

    '
    ' GET: /Mp/

    Function Index() As ActionResult
        Dim mps = db.Mps.Include(Function(m) m.Pa)
        Return View(mps.ToList())
    End Function

    '
    ' GET: /Mp/Details/5

    Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim mp As Mp = db.Mps.Find(id)
        If IsNothing(mp) Then
            Return HttpNotFound()
        End If
        Return View(mp)
    End Function

    '
    ' GET: /Mp/Create

    Function Create() As ActionResult
        ViewBag.PaId = New SelectList(db.Pas, "Id", "Nome")
        Return View()
    End Function

    '
    ' POST: /Mp/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal mp As Mp) As ActionResult
        If ModelState.IsValid Then
            db.Mps.Add(mp)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        ViewBag.PaId = New SelectList(db.Pas, "Id", "Nome", mp.PaId)
        Return View(mp)
    End Function

    '
    ' GET: /Mp/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim mp As Mp = db.Mps.Find(id)
        If IsNothing(mp) Then
            Return HttpNotFound()
        End If
        ViewBag.PaId = New SelectList(db.Pas, "Id", "Nome", mp.PaId)
        Return View(mp)
    End Function

    '
    ' POST: /Mp/Edit/5

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal mp As Mp) As ActionResult
        If ModelState.IsValid Then
            db.Entry(mp).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        ViewBag.PaId = New SelectList(db.Pas, "Id", "Nome", mp.PaId)
        Return View(mp)
    End Function

    '
    ' GET: /Mp/Delete/5

    Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim mp As Mp = db.Mps.Find(id)
        If IsNothing(mp) Then
            Return HttpNotFound()
        End If
        Return View(mp)
    End Function

    '
    ' POST: /Mp/Delete/5

    <HttpPost()> _
    <ActionName("Delete")> _
    <ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
        Dim mp As Mp = db.Mps.Find(id)
        db.Mps.Remove(mp)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class