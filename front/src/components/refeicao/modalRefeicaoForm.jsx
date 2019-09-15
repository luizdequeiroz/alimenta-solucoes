import React, { useEffect } from 'react';
import { Modal } from 'react-bootstrap';
import { bindReduxForm } from '../../config/binders';

import { Field, initialize } from 'redux-form';
import Input from '../divers/input';

import { formatDate } from '../../utils';
import { treatRefeicoes } from '../../treatments';
import { get } from '../../config/actions';

function validate(values) {
    const errors = {};

    if (!values.tiporefeicao) {
        errors.tiporefeicao = 'Informe o tipo de refeição.';
    }

    return errors;
}

// const updateClienteComRefeicao = (dias, refeicao, tiporefeicao) => ({
//     ...dias,
//     dias: dias.dias.map(dia => {
//         if (dia.dataRefeicao === refeicao.dataRefeicao) {
//             const dias = dia.dias ? dia.dias.filter(r => r.numsequencial !== refeicao.numsequencial) : [];
//             dias.push({
//                 ...refeicao,
//                 tiporefeicao
//             });
//             return { ...dia, dias };
//         } else {
//             return dia;
//         }
//     })
// });

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
        const { clienteId, dataRefeicao } = refeicao;
        const tiporefeicao = formValues;
        const url = refeicao.id ?
            `refeicao/${clienteId}/${dataRefeicao}/${refeicao.id}`
            : `refeicao/${clienteId}/${dataRefeicao}`;

        put(url, 'refeicaoRegistro', {
            param: { ...refeicao, tiporefeicao },
            callback: get(`refeicao/${pesquisaRefeicaoFiltros.clienteRefeicao}/${pesquisaRefeicaoFiltros.dataInicial}/${pesquisaRefeicaoFiltros.dataFinal}/${pesquisaRefeicaoFiltros.tipoRefeicao || ''}`, 'dias', { treatment: treatRefeicoes }),
        });
        onHide();
    }

    return (
        <Modal show={show} centered>
            <Modal.Header className="alert-primary">
                <Modal.Title>Adicionar refeição ao dia {formatDate(refeicao.dataRefeicao)}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <form onSubmit={salvar}>
                    <Field name="tipoString" component={Input} type="select" placeholder="Tipo de Refeição">
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