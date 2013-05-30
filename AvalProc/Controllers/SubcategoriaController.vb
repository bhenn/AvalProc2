Imports System.Data.Entity

Public Class SubcategoriaController
    Inherits System.Web.Mvc.Controller

    Private db As New AvalProcContexto

    '
    ' GET: /Subcategoria/

    Function Index() As ActionResult
        Return View(db.SubCategorias.Include(Function(x) x.Categoria).ToList())
    End Function

    '
    ' GET: /Subcategoria/Details/5

    Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim subcategoria As SubCategoria = db.SubCategorias.Find(id)
        If IsNothing(subcategoria) Then
            Return HttpNotFound()
        End If
        Return View(subcategoria)
    End Function

    '
    ' GET: /Subcategoria/Create

    Function Create() As ActionResult
        ViewBag.categoriaId = New SelectList(db.Categorias.ToList, "Id", "Descricao")

        Return View()
    End Function

    '
    ' POST: /Subcategoria/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal subcategoria As SubCategoria) As ActionResult
        If ModelState.IsValid Then
            db.SubCategorias.Add(subcategoria)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        ViewBag.categoriaId = New SelectList(db.Categorias.ToList, "Id", "Descricao")

        Return View(subcategoria)
    End Function

    '
    ' GET: /Subcategoria/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim subcategoria As SubCategoria = db.SubCategorias.Find(id)
        If IsNothing(subcategoria) Then
            Return HttpNotFound()
        End If
        Return View(subcategoria)
    End Function

    '
    ' POST: /Subcategoria/Edit/5

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal subcategoria As SubCategoria) As ActionResult
        If ModelState.IsValid Then
            db.Entry(subcategoria).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(subcategoria)
    End Function

    '
    ' GET: /Subcategoria/Delete/5

    Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim subcategoria As SubCategoria = db.SubCategorias.Find(id)
        If IsNothing(subcategoria) Then
            Return HttpNotFound()
        End If
        Return View(subcategoria)
    End Function

    '
    ' POST: /Subcategoria/Delete/5

    <HttpPost()> _
    <ActionName("Delete")> _
    <ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
        Dim subcategoria As SubCategoria = db.SubCategorias.Find(id)
        db.SubCategorias.Remove(subcategoria)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class