Imports System.Data.Entity

<Authorize>
Public Class TipoAvaliadorController
    Inherits System.Web.Mvc.Controller

    Private db As New AvalProcContexto

    '
    ' GET: /TipoAvaliador/

    Function Index() As ActionResult
        Return View(db.TipoAvaliadores.ToList())
    End Function

    '
    ' GET: /TipoAvaliador/Details/5

    Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim tipoavaliador As TipoAvaliador = db.TipoAvaliadores.Find(id)
        If IsNothing(tipoavaliador) Then
            Return HttpNotFound()
        End If
        Return View(tipoavaliador)
    End Function

    '
    ' GET: /TipoAvaliador/Create

    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /TipoAvaliador/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal tipoavaliador As TipoAvaliador) As ActionResult
        If ModelState.IsValid Then
            db.TipoAvaliadores.Add(tipoavaliador)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(tipoavaliador)
    End Function

    '
    ' GET: /TipoAvaliador/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim tipoavaliador As TipoAvaliador = db.TipoAvaliadores.Find(id)
        If IsNothing(tipoavaliador) Then
            Return HttpNotFound()
        End If
        Return View(tipoavaliador)
    End Function

    '
    ' POST: /TipoAvaliador/Edit/5

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal tipoavaliador As TipoAvaliador) As ActionResult
        If ModelState.IsValid Then
            db.Entry(tipoavaliador).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(tipoavaliador)
    End Function

    '
    ' GET: /TipoAvaliador/Delete/5

    Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim tipoavaliador As TipoAvaliador = db.TipoAvaliadores.Find(id)
        If IsNothing(tipoavaliador) Then
            Return HttpNotFound()
        End If
        Return View(tipoavaliador)
    End Function

    '
    ' POST: /TipoAvaliador/Delete/5

    <HttpPost()> _
    <ActionName("Delete")> _
    <ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
        Dim tipoavaliador As TipoAvaliador = db.TipoAvaliadores.Find(id)
        db.TipoAvaliadores.Remove(tipoavaliador)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class