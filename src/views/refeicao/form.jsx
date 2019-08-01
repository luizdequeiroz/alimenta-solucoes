import React, { Component } from 'react';
import { bindReduxForm } from '../../config/binders';
import { Field, initialize } from 'redux-form';
import Input from '../../components/input';
import { post } from '../../config/actions';
import swal from 'sweetalert2';

function register(values) {

    return post('refeicao/salvar', 'registro', { param: values });
}

function validate(values) {

    const errors = {};

    if (!values.refeicao) {
        errors.refeicao = 'Refeição é obrigatório.';
    }

   
    return errors;
}

class RefeicaoForm extends Component {

    componentDidMount() {
        const { dispatch, form, refeicao } = this.props;

        dispatch(initialize(form, refeicao));
    }

    cancelar() {
        const { cancelar, dispatch, form, refeicao } = this.props;
        
        dispatch(initialize(form, refeicao));
        cancelar();
    }

    render() {
        const { handleSubmit, registro } = this.props;

        if (registro && registro.stack) {
            swal.fire('Erro ao tentar registrar!', 'O sistema acionou uma exceção ao tentar registrar um usuário.', 'error');
        }

        return (
            <form onSubmit={handleSubmit}>
                <div className="form-inline">
                    <Field name="usuario" component={Input} type="text" placeholder="Usuário" popoverPosition="top" />
                    <Field name="senha" component={Input} type="password" placeholder="Senha" popoverPosition="top" />
                    <div className="btn btn-warning" onClick={this.cancelar.bind(this)}>Cancelar</div>
                </div>
                <input type="submit" className="btn btn-primary btn-lg btn-block" value="Cadastrar" />
            </form>
        );
    }
}

export default bindReduxForm('usuario', 'registro')(register)(validate)(RefeicaoForm);