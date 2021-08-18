function ValidarCampos(tela) {
    var ret = true;
    
    switch (tela) {
        case 1: //tela de categoria
            if ($("#nome_categoria").val().trim() == "") {
                ret = false;
                $("#val_nome_categoria").show().html("Preencher o campo Nome");
            }else {
                $("#val_nome_categoria").hide();
            }          
            break;
            
        case 2: //tela empresa
            if ($("#nome_empresa").val().trim() == "") {
                ret = false;
                $("#val_nome_empresa").show().html("Preencher o campo Nome");
            }else {
                $("#val_nome_empresa").hide();
            }
            if ($("#endereco_empresa").val().trim() == "") {
                ret = false;
                $("#val_end_empresa").show().html("Preencher o campo Endereço");
            }else {
                $("#val_end_empresa").hide();
            }
            if ($("#telefone_empresa").val().trim() == "") {
                ret = false;
                $("#val_tel_empresa").show().html("Preencher o campo Telefone");
            }else {
                $("#val_tel_empresa").hide();
            }

            break;
        case 3: //tela banco
            if ($("#codigo_banco").val().trim() == "") {
                ret = false;
                $("#val_cod_banco").show().html("Preencher o campo Código");
            }else {
                $("#val_cod_banco").hide();
            }
            if ($("#nome_banco").val().trim() == "") {
                ret = false;
                $("#val_nome_banco").show().html("Preencher o campo Nome");
            }else {
                $("#val_nome_banco").hide();
            }
            break;
        case 4: //tela conta
            if ($("#banco_conta").val().trim() == "") {
                ret = false;
                $("#val_ban_conta").show().html("Selecione o Banco");
            }else {
                $("#val_ban_conta").hide();
            }
            if ($("#agencia_conta").val().trim() == "") {
                ret = false;
                $("#val_ag_conta").show().html("Preencher o campo Agencia");
            }else {
                $("#val_ag_conta").hide();
            }
            if ($("#numero_conta").val().trim() == "") {
                ret = false;
                $("#val_num_conta").show().html("Preencher o campo Número");
            }else {
                $("#val_num_conta").hide();
            }
            if ($("#saldo_conta").val().trim() == "") {
                ret = false;
                $("#val_saldo_conta").show().html("Preencher o campo Saldo");
            }else {
                $("#val_saldo_conta").hide();
            }
            break;
        case 5: //tela movimentacao
            if ($("#tipo_mov").val().trim() == "") {
                ret = false;
                $("#val_tipo_mov").show().html("Selecione o Tipo");
            }else {
                $("#val_tipo_mov").hide();
            }
            if ($("#data_mov").val().trim() == "") {
                ret = false;
                $("#val_data_mov").show().html("Preencher o campo Data");
            }else {
                $("#val_data_mov").hide();
            }
            if ($("#conta_mov").val().trim() == "") {
                ret = false;
                $("#val_conta_mov").show().html("Selecione a Conta");
            }else {
                $("#val_conta_mov").hide();
            }
            if ($("#empresa_mov").val().trim() == "") {
                ret = false;
                $("#val_empresa_mov").show().html("Selecione a Empresa");
            }else {
                $("#val_empresa_mov").hide();
            }
            if ($("#categoria_mov").val().trim() == "") {
                ret = false;
                $("#val_categoria_mov").show().html("Selecione a Categoria");
            }else {
                $("#val_categoria_mov").hide();
            }
            if ($("#valor_mov").val().trim() == "") {
                ret = false;
                $("#val_valor_mov").show().html("Preencher o campo Valor");
            }else {
                $("#val_valor_mov").hide();
            }
            break;
        case 6: //tela login
            if ($("#email_login").val().trim() == "") {
                ret = false;
                $("#val_email_login").show().html("Preencher o campo Email");
            }else {
                $("#val_email_login").hide();
            }
            if ($("#senha_login").val().trim() == "") {
                ret = false;
                $("#val_senha_login").show().html("Preencher o campo Senha");
            }else {
                $("#val_senha_login").hide();
            }
            break;
        case 7: //tela cadastro
            if ($("#nome_login").val().trim() == "") {
                ret = false;
                $("#val_nome_login").show().html("Preencher o campo Nome");
            }else {
                $("#val_nome_login").hide();
            }
            if ($("#email_login").val().trim() == "") {
                ret = false;
                $("#val_email_login").show().html("Preencher o campo Email");
            }else {
                $("#val_email_login").hide();
            }
            if ($("#senha_login").val().trim() == "") {
                ret = false;
                $("#val_senha_login").show().html("Preencher o campo Senha");
            }else {
                $("#val_senha_login").hide();
            }
            break;
    }
    
    return ret;
}