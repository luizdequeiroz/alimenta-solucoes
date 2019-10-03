import React, { useEffect } from 'react';
import { Modal } from 'react-bootstrap';
import { bindReduxForm } from '../../config/binders';

import { Field, initialize } from 'redux-form';
import Input from '../divers/input';

import { formatDate } from '../../utils';
import { treatDefault as treatment } from '../../treatments';
import { get } from '../../config/actions';

function validate(values) {
    const errors = {};

    if (!values.tiporefeicao) {
        errors.tiporefeicao = 'Informe o tipo de refeição.';
    }

    return errors;
}

export default bindReduxForm('refeicao', 'pesquisaRefeicaoFiltros')()(validate)(({ show, onHide, dispatch, form, refeicao, put, formValues, setValue, pesquisaRefeicaoFiltros }) => {
    useEffect(() => {
        if (refeicao) {
            dispatch(initialize(form, refeicao));
        }

        return () => {
            setValue('refeicao');
        };
    }, [dispatch, form, refeicao, setValue]);

    function salvar(e) {
        e.preventDefault();
        const { cliente, datarefeicao } = refeicao;
        const tiporefeicao = formValues;
        const url = `refeicao/${cliente}/${datarefeicao}`;

        put(url, 'refeicaoRegistro', {
            param: { ...refeicao, tiporefeicao },
            callback: get(`cliente/refeicoes/${pesquisaRefeicaoFiltros.clienteRefeicao}/${pesquisaRefeicaoFiltros.dataInicial}/${pesquisaRefeicaoFiltros.dataFinal}/${pesquisaRefeicaoFiltros.tipoRefeicao}`, 'clienteComRefeicoes', { treatment })
        });
        onHide();
    }

    return (
        <Modal show={show} centered>
            <Modal.Header className="alert-primary">
                <Modal.Title>Adicionar refeição ao dia {formatDate(refeicao.datarefeicao)}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <form onSubmit={salvar}>
                    <Field name="tiporefeicao" component={Input} type="select" placeholder="Tipo de Refeição">
                        <option>Café da manhã</option>
                        <option>Almoço</option>
                        <option>Jantar</option>
                    </Field>
                    <hr />
                    <div className="btn btn-warning" onClick={onHide}><i className="fa fa-arrow-left" /> Voltar</div>
                    <button type="submit" className="btn btn-primary"><i className="fa fa-plus" /> Adicionar</button>
                </form>
            </Modal.Body>
        </Modal>
    );
}, 'tiporefeicao');