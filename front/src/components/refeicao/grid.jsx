import React, { useState, useEffect } from 'react';
import { bindDefault } from '../../config/binders';
import { formatDate } from '../../utils';
import ModalRefeicaoForm from './modalRefeicaoForm';
import swal from 'sweetalert2';

let count = 0;

export default bindDefault('dias', 'refeicaoRegistro')(({ dias, setValue, refeicaoRegistro }) => {
    const [showModal, setShowModal] = useState(false);

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
            setValue('dias');
        };
    }, [refeicaoRegistro, setValue]);

    function abrirFormRefeicao(refeicao) {
        setShowModal(true);
        setValue('refeicao', refeicao)
    }
    debugger;
    const clienteView = (
        <div style={{ marginTop: '40px', marginBottom: '50px' }}>
            {/* Grid para cardapio */}
            <div>
                {/* Clintes */}
                <div className="gridCliente">
                    <div>{dias && dias.find(d => d.refeicoes[0].Id > 0).clienteNome}</div>
                </div>
                {dias && dias.map((dia, index) => {
                    count++;
debugger;
                    const diaView = (
                        <>
                            <div key={index} className="gridDia">
                                <div className="card-header card-header-primary gridDiaSemana">
                                    {formatDate(dia.dataRefeicao)}
                                </div>
                                {dia.refeicoes && dia.refeicoes.filter(r => r.Id > 0).map((refeicao, jndex) => (
                                    <div key={jndex} className="btn-group pull-right group-buttons">
                                        <div className="btn btn-link">{refeicao.tipoString}</div>
                                        <div className="btn btn-link" onClick={() => abrirFormRefeicao(refeicao)}><i className="fa fa-edit iconEditar" /></div>
                                        <div className="btn btn-link"><i className="fa fa-close iconFechar" /></div>
                                    </div>
                                ))}
                                <div className="card-body">
                                    <div className="btn btn-add btn-add-block btn-success" onClick={() => abrirFormRefeicao({
                                        dataRefeicao: dia.dataRefeicao,
                                        cliente: dias.find(r => r.Id > 0).clienteId
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