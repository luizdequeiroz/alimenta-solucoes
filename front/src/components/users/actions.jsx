import React, { useEffect } from 'react';
import { bindDefault } from '../../config/binders';

import swal from 'sweetalert2';
import { API_DOTNET } from '../../utils';
import { get } from '../../config/actions';
import { treatDefault as treatment } from '../../treatments';

export default bindDefault('usuarioDel')(({ usuario, setValue, del, usuarioDel }) => {

    useEffect(() => {
        
        if (usuarioDel && usuarioDel.stack) {
            swal.fire('Erro ao tentar excluir!', 'O sistema acionou uma exceção na tentativa de excluir o usuário!', 'error');
        }
    }, [usuarioDel])

    function editarUsuario() {

        setValue('usuarioRegistro');
        setValue('usuario', usuario);
    }

    function deleteUsuario(codigo) {

        swal.fire({
            type: 'question',
            title: 'Confirma a exclusão de usuários?',
            text: 'Tem certeza de que deseja excluir o usuários?',
            showCancelButton: true,
            cancelButtonText: 'Não',
            showConfirmButton: true,
            confirmButtonText: 'Sim'
        }).then(({ value }) => {
            if (value) {
                del(`Usuarios/${codigo}`, 'usuarioDel', { api: API_DOTNET, callback: get('Usuarios', 'usuarios', { api: API_DOTNET, treatment }) });
            }
        });
    }

    return (
        <div className="btn-group btn-actions">
            <div className="btn btn-primary btn-sm" onClick={editarUsuario}>Editar</div>
            <div className="btn btn-danger btn-sm" onClick={() => deleteUsuario(usuario.id)}>Excluir</div>
        </div>
    );
});