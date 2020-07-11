<!DOCTYPE html>
<html lang="pt-br">
<head>
    <title>Formulário de contado</title>
    <meta charset="utf-8">
    <link rel="stylesheet" type="text/css" href="estilo'-'.css">
</head>
<body>
    <form class="formulario" method="post">
        <?php
            //Esse código em php salva as informções do usuário no servidor 
             if (isset($_POST["acao"]))
            {
                $nome=$_POST["nome"];
                $telefone=$_POST["telefone"];
                $email=$_POST["email"];
                $radio=$_POST["novidades"];
                $msg=$_POST["mensagem"];
                $estado=$_POST["estado"];

              /*echo"<p>Olá, ".$nome."</p>";
                echo "<p>Seu email é: ".$email."</p>";
                echo "<p>Seu telefone é: ".$telefone."</p>";
                echo "<p>Seu estado é: ".$estado."</p>";
                echo "<p>Sua mensagem é:<br/>".$msg."</p>";*/
            }
        ?>
        <p><b> Envie uma mensagem preenchendo o formulário abaixo </b></p>
            
        <!-- Essa parte do código que está em Html é onde o usuário insere suas informações -->
        <div class="field">
            <label for="nome"><b>Seu nome:</b></label>
            <input type="text" id="nome" name="nome" placeholder="Digite seu nome*" required="">
        </div>
        <br />
        <div class="fiel">
            <label for="telefone"><b>Seu Telefone:</b></label>
            <input type="nunber" maxlength="8" name="telefone" id="telefone" placeholder="Digite seu Telefone*"  required="" onkeypress='return SomenteNumero(event)'> 
        </div>
        <br />
        <div class="fiel">
            <label for="email"><b>Seu E-Mail:</b></label>
            <input  type="email" name="email" id="email" placeholder="Digite su e-mail*" required="">
        </div>
        <br />
        <div>
        <label id="estado"><b>Estado: </b></label>
        <select name="estado"> 
    				<option value="AC">Acre</option> 
    				<option value="AL">Alagoas</option> 
   					<option value="Am">Amazonas</option> 
    				<option value="AP">Amapá</option> 
    				<option value="BA">Bahia</option> 
    				<option value="CE">Ceará</option> 
    				<option value="DF">Distrito Federal</option> 
    				<option value="ES">Espírito Santo</option> 
    				<option value="GO">Goiás</option> 
    				<option value="MA">Maranhão</option> 
    				<option value="MT">Mato Grosso</option> 
    				<option value="MS">Mato Grosso do Sul</option> 
    				<option value="MG">Minas Gerais</option> 
    				<option value="PA">Pará</option> 
    				<option value="PB">Paraíba</option> 
    				<option value="PR">Paraná</option> 
    				<option value="PR">Pernambuco</option> 
    				<option value="PI">Piauí</option> 
    				<option value="RJ">Rio de Janeiro</option> 
    				<option value="RN">Rio Grande do Norte</option> 
    				<option value="RO">Rondônia</option> 
    				<option value="RS">Rio Grande do Sul</option> 
    				<option value="RR">Roraima</option> 
    				<option value="SC">Santa Catarina</option> 
    				<option value="SE">Sergipe</option> 
    				<option value="SP">São Paulo</option> 
    				<option value="TO">Tocantins</option> 
   				</select>
        </div>
        <br />
        <div class="field">
            <label for="mensagem"><b>Sua mensagem:</b></label>
            <textarea name="mensagem" id="mensagem" placeholder="Mensagem*" required></textarea>
        </div>
    
        <input type="submit" name="acao" value="Enviar">
    </form>
</body>
<script language='JavaScript'>
    function SomenteNumero(e){
        var tecla=(window.event)?event.keyCode:e.which;   
            if((tecla>47 && tecla<58)) return true;
                else{
    	            if (tecla==8 || tecla==0) return true;
	            else  return false;
                }
    }
</script>
 
</html>
