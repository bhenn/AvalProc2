@ModelType avalproc.Usuario 


@Code
    ViewData("Title") = "Login"
End Code


<div class="span4">

    @Using Html.BeginForm()
        
        @<div class="form-signin">

            <fieldset>
                <legend>Login</legend>

                <div class="input-prepend">
                <span class="add-on"><i class="icon-envelope"></i></span>
                <input type="text" class="input-block-level" id="Email" name="Email" placeholder="Email" />
                </div>

                <div class="input-prepend">
                <span class="add-on"><i class="icon-asterisk"></i></span>
                <input type="password" class="input-block-level" id="Senha" name="Senha" placeholder="Senha">
                </div>
                
                <p>
                    <button class="btn" type="submit">Login</button>
                </p>
            </fieldset>
            
        </div>

        End Using



</div>


@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section


