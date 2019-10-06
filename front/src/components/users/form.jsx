import React, { Component } from 'react';
import { bindReduxForm } from '../../config/binders';
import { Field, initialize } from 'redux-form';
import Input from '../divers/input';
import { post, put, get, setValue } from '../../config/actions';
import swal from 'sweetalert2';
import { API_DOTNET } from '../../utils';
import { treatDefault as treatment } from '../../treatments'

function register(values, route, props) {

    const config = {
        api: API_DOTNET,
        param: values,
        callback: [
            get('Usuarios', 'usuarios', { api: API_DOTNET, treatment }),
            setValue('usuario')
        ]
    };

    if (props.usuario) {
        return put(`Usuarios/${props.usuario.id}`, 'usuarioAtualizacao', config);
    } else {
        return post('Usuarios', 'usuarioRegistro', config);
    }
}

function validate(values) {

    const errors = {};

    if (!values.nome) {
        errors.nome = 'Usuário obrigatório.';
    }

    if (!values.senha) {
        errors.senha = 'Senha obrigatória.';
    }

    return errors;
}

class UserForm extends Component {

    componentDidMount() {
        const { dispatch, form, usuario } = this.props;

        dispatch(initialize(form, usuario));
    }

    cancelar() {
        const { setValue } = this.props;

        setValue('usuario');
        setValue('usuarioRegistro');
        setValue('usuarioAtualizacao');
    }

    render() {
        const { handleSubmit, usuarioRegistro, usuarioAtualizacao } = this.props;

        if (usuarioAtualizacao && usuarioAtualizacao.stack) {
            swal.fire('Erro ao tentar atualizar!', 'O sistema acionou uma exceção ao tentar atualizar o usuário.', 'error');
        }

        if (usuarioRegistro && usuarioRegistro.stack) {
            swal.fire('Erro ao tentar registrar!', 'O sistema acionou uma exceção ao tentar registrar um usuário.', 'error');
        }

        return (
            <form onSubmit={handleSubmit}>
                <div className="form-inline">
                    <Field name="nome" component={Input} type="text" placeholder="Usuário" popoverPosition="top" />
                    <Field name="senha" component={Input} type="password" placeholder="Senha" popoverPosition="top" />
                    <div className="btn btn-warning" onClick={this.cancelar.bind(this)}>Cancelar</div>
                </div>
                <input type="submit" className="btn btn-primary btn-lg btn-block" value="Salvar" />
            </form>
        );
    }
}

export default bindReduxForm('usuario', 'usuarioRegistro', 'usuarioAtualizacao')(register)(validate)(UserForm);