import React, { useState, useEffect } from 'react';
import { bindDefault } from '../../config/binders';
import { formatDate } from '../../utils';
import ModalRefeicaoForm from './modalRefeicaoForm';
import swal from 'sweetalert2';
import { treatDefault as treatment } from '../../treatments';

let count = 0;

export default bindDefault('clienteComRefeicoes', 'refeicaoRegistro', 'refeicaoDel', 'pesquisaRefeicaoFiltros')(({ clienteComRefeicoes, setValue, refeicaoRegistro, refeicaoDel, del, get, pesquisaRefeicaoFiltros }) => {
    const [showModal, setShowModal] = useState(false);

    useEffect(() => {
        if(refeicaoDel) {
            if(refeicaoDel.sucesso){
                swal.fire('Refeição excluida com sucesso!', 'A refeição foi excluida para o dia e para o cliente em exibição!', 'success');
            }
            setValue('refeicaoDel');
        }
    }, [refeicaoDel, setValue]);

    useEffect(() => {
        if (refeicaoRegistro) {
            if (refeicaoRegistro.sucesso) {
                swal.fire('Refeição salva com sucesso!', 'Os dados da refeição foram salvos com sucesso!', 'success');
            } else if (refeicaoRegistro.stack) {
                swal.fire('Erro ao tentar salvar!', 'O sistema acionou uma exceção ao tentar salvar uma refeição.', 'error');
            }
            setValue('refeicaoRegistro');
        }

        return () => {
            setValue('clienteComRefeicoes');
        };
    }, [refeicaoRegistro, setValue]);

    function abrirFormRefeicao(refeicao) {
        setShowModal(true);
        setValue('refeicao', refeicao)
    }

    function deletarRefeicao(codigo) {

        swal.fire({
            type: 'question',
            title: 'Confirma a exclusão da refeição?',
            text: 'Tem certeza de que deseja excluir a refeição?',
            showCancelButton: true,
            cancelButtonText: 'Não',
            showConfirmButton: true,
            confirmButtonText: 'Sim'
        }).then(({ value }) => {
            if (value) {
                del(`refeicao/${codigo}`, 'refeicaoDel', { callback: get(`cliente/refeicoes/${pesquisaRefeicaoFiltros.clienteRefeicao}/${pesquisaRefeicaoFiltros.dataInicial}/${pesquisaRefeicaoFiltros.dataFinal}/${pesquisaRefeicaoFiltros.tipoRefeicao}`, 'clienteComRefeicoes', { treatment }) });
            }
        });
    }

    const clienteView = (
        <div style={{ marginTop: '40px', marginBottom: '50px' }}>
            {/* Grid para cardapio */}
            <div>
                {/* Clintes */}
                <div className="gridCliente">
                    {clienteComRefeicoes && <div className="alert alert-warning">{clienteComRefeicoes.nome}</div>}
                </div>
                {clienteComRefeicoes && clienteComRefeicoes.dias && clienteComRefeicoes.dias.map((dia, index) => {
                    count++;

                    const diaView = (
                        <>
                            <div key={index} className="gridDia">
                                <div className="card-header card-header-primary gridDiaSemana">
                                    {formatDate(dia.datarefeicao)}
                                </div>
                                {dia.refeicoes && dia.refeicoes.map((refeicao, jndex) => (
                                    <div key={jndex} className="btn-group pull-right group-buttons">
                                        <div className="btn btn-link">{refeicao.tiporefeicao}</div>
                                        <div className="btn btn-link" onClick={() => abrirFormRefeicao(refeicao)}><i className="fa fa-edit iconEditar" /></div>
                                        <div className="btn btn-link" onClick={() => deletarRefeicao(refeicao.numsequencial)}><i className="fa fa-close iconFechar" /></div>
                                    </div>
                                ))}
                                <div className="card-body">
                                    <div className="btn btn-add btn-add-block btn-success" onClick={() => abrirFormRefeicao({
                                        datarefeicao: dia.datarefeicao,
                                        cliente: clienteComRefeicoes.numsequencial
                                    })}>Adicionar</div>
                                </div>
                            </div>
                            {count === 7 &&
                                <div className="col-md-12 content-is-hr">
                                    <hr />
                                </div>}
                        </>
                    );

                    count = count === 7 ? 0 : count;
                    return diaView;
                })}
            </div>
            {showModal && <ModalRefeicaoForm show={showModal} onHide={() => setShowModal(false)} />}
        </div>
    );

    count = 0;
    return clienteView;
});