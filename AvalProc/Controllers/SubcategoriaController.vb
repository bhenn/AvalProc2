Imports System.Data.Entity

<Authorize>
Public Class SubcategoriaController
    Inherits System.Web.Mvc.Controller

    Private db As New AvalProcContexto

    '
    ' GET: /Subcategoria/

    Function Index() As ActionResult
        Return View()
    End Function

    Function List() As ActionResult
        Return PartialView(db.SubCategorias.Include(Function(x) x.Categoria).ToList())
    End Function

    '
    ' GET: /Subcategoria/Create

    Function Create() As ActionResult
        ViewBag.categoriaId = New SelectList(db.Categorias.ToList, "Id", "Descricao")

        Return PartialView()
    End Function

    '
    ' POST: /Subcategoria/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal subcategoria As SubCategoria) As ActionResult
        If ModelState.IsValid Then
            db.SubCategorias.Add(subcategoria)
            db.SaveChanges()
            Return RedirectToAction("List")
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

        'ViewBag.categoriaId = New SelectList(db.Categorias.ToList, "Id", "Descricao", subcategoria.CategoriaId)
        ViewBag.categorias = db.Categorias.ToList
        Return PartialView(subcategoria)
    End Function

    '
    ' POST: /Subcategoria/Edit/5

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal subcategoria As SubCategoria) As ActionResult
        If ModelState.IsValid Then
            db.Entry(subcategoria).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("List")
        End If

        Return PartialView(subcategoria)
    End Function

    '
    ' POST: /Subcategoria/Delete/5

    <HttpPost()> _
    Function Delete(ByVal id As Integer) As RedirectToRouteResult
        Dim subcategoria As SubCategoria = db.SubCategorias.Find(id)
        db.SubCategorias.Remove(subcategoria)
        db.SaveChanges()
        Return RedirectToAction("List")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class