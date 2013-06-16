@ModelType avalproc.Usuario 


@Code
    ViewData("Title") = "Login"
End Code


<div class="span4">

    @Using Html.BeginForm()
        
        @<div class="form-signin">

            <fieldset>
                <legend>Login</legend>

                <input type="text" class="input-block-level" id="Email" name="Email" placeholder="Email" />
                <input type="password" class="input-block-level" id="Senha" name="Senha" placeholder="Senha">

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


