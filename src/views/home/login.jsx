import React, { Component } from 'react';
import { bindReduxForm } from '../../stores/binders';
import { post } from '../../stores/actions';

import Loading from '../../components/loading';
import Input from '../../components/input';

import { Field } from 'redux-form';

function login(values) {

    return post('usuario/login', 'session', values, { withProccess: true, msgProccess: 'Autenticando...', withWarningAlert: true, msgWarningAlert: 'E-mail ou senha incorreto!', withErrorAlert: true, msgErrorAlert: 'Erro de comunicação com serviço de autenticação.' });
}

function validate(values) {

    const errors = {};

    if (!values.usuario) {
        errors.usuario = 'Usuário/E-mail obrigatório.';
    }

    if (!values.senha) {
        errors.senha = 'Senha obrigatória.';
    }

    return errors;
}

class Login extends Component {

    render() {

        return (
            <div className="content-centered">
                <div className="card">
                    <div className="card-header card-header-primary">
                        <h4 className="card-title">Entrada <Loading /></h4>
                    </div>
                    <div className="card-body">
                        <form onSubmit={this.props.handleSubmit}>
                            <div className="row">
                                <div className="col-md-12">
                                    <div className="form-group">
                                        <Field name="usuario" component={Input} type="text" placeholder="Usuário ou e-mail" />
                                    </div>
                                </div>
                                <div className="col-md-12">
                                    <div className="form-group">
                                        <Field name="senha" component={Input} type="password" placeholder="Senha" />
                                    </div>
                                </div>
                            </div>
                            <input type="submit" className="btn btn-primary pull-right" value="Entrar" />
                            <div className="clearfix"></div>
                        </form>
                    </div>
                </div>
            </div>
        );
    }
}

export default bindReduxForm()(login)(validate)(Login);