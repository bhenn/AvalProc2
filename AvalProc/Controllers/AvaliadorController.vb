Imports System.Data.Entity

Public Class AvaliadorController
    Inherits System.Web.Mvc.Controller

    Private db As New AvalProcContexto

    '
    ' GET: /Avaliador/

    Function Index() As ActionResult
        Return View(db.Avaliadores.ToList())
    End Function

    Function List() As ActionResult
        Return PartialView(db.Avaliadores.ToList())
    End Function

    '
    ' GET: /Avaliador/Create

    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Avaliador/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal avaliador As Avaliador) As ActionResult
        If ModelState.IsValid Then
            db.Avaliadores.Add(avaliador)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(avaliador)
    End Function

    '
    ' GET: /Avaliador/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim avaliador As Avaliador = db.Avaliadores.Find(id)
        If IsNothing(avaliador) Then
            Return HttpNotFound()
        End If
        Return PartialView(avaliador)
    End Function

    '
    ' POST: /Avaliador/Edit/5

    <HttpPost()> _
    Function Edit(ByVal avaliador As Avaliador) As ActionResult
        If ModelState.IsValid Then
            db.Entry(avaliador).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("List")
        End If

        Return View(avaliador)
    End Function

    '
    ' GET: /Avaliador/Delete/5

    Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim avaliador As Avaliador = db.Avaliadores.Find(id)
        If IsNothing(avaliador) Then
            Return HttpNotFound()
        End If
        Return View(avaliador)
    End Function

    '
    ' POST: /Avaliador/Delete/5

    <HttpPost()> _
    <ActionName("Delete")> _
    <ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
        Dim avaliador As Avaliador = db.Avaliadores.Find(id)
        db.Avaliadores.Remove(avaliador)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class