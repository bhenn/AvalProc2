Imports System.Data.Entity

<Authorize>
Public Class ProcessoController
    Inherits System.Web.Mvc.Controller

    Private db As New AvalProcContexto

    '
    ' GET: /Processo/

    Function Index() As ActionResult
        Return View()
    End Function

    Function List() As ActionResult
        Return PartialView(db.Processos.Include(Function(x) x.SubCategoria).ToList())
    End Function

    '
    ' GET: /Processo/Create

    Function Create() As ActionResult
        ViewBag.SubCategoriaId = New SelectList(db.SubCategorias, "Id", "Descricao")
        Return PartialView()
    End Function



    '
    ' POST: /Processo/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal processo As Processo) As ActionResult
        If ModelState.IsValid Then
            db.Processos.Add(processo)
            db.SaveChanges()
            Return RedirectToAction("List")
        End If

        ViewBag.SubCategoriaId = New SelectList(db.SubCategorias, "Id", "Descricao", processo.SubCategoriaId)
        Return View(processo)
    End Function

    '
    ' GET: /Processo/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim processo As Processo = db.Processos.Find(id)
        If IsNothing(processo) Then
            Return HttpNotFound()
        End If
        ViewBag.SubCategorias = db.SubCategorias.ToList
        Return PartialView(processo)
    End Function

    '
    ' POST: /Processo/Edit/5

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal processo As Processo) As ActionResult
        If ModelState.IsValid Then
            db.Entry(processo).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("List")
        End If

        ViewBag.SubCategoriaId = New SelectList(db.SubCategorias, "Id", "Descricao", processo.SubCategoriaId)
        Return View(processo)
    End Function

    '
    ' POST: /Processo/Delete/5

    <HttpPost()> _
    Function Delete(ByVal id As Integer) As ActionResult
        Dim processo As Processo = db.Processos.Find(id)
        db.Processos.Remove(processo)
        db.SaveChanges()
        Return RedirectToAction("List")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class