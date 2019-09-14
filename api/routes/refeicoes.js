var express = require('express');
var router = express.Router();
var models = require('../models/index');

/**
 * @swagger
 * /refeicao/{clienteId}/{datarefeicao}/{refeicaoId?}:
 *   post:
 *     description: Realiza login de usuário, gerando token
 *     parameters:
 *       - name: clienteId
 *         in: path
 *         required: true
 *         type: string
 *       - name: datarefeicao
 *         in: path
 *         required: true
 *         type: string
 *       - name: refeicaoId
 *         in: path
 *         required: false
 *         type: string
 *       - name: dados
 *         in: body
 *         required: true
 *         schema:
 *           type: object
 *           required:
 *             - usuario
 *             - senha
 *           properties:
 *             usuario:
 *               type: string
 *             senha:
 *               type: string
 *     produces:
 *       - application/json
 *     responses:
 *       200:
 *         description: objeto com um token de sessão
 */
router.put('/:clienteId/:datarefeicao/:refeicaoId?', (req, res, next) => {
    const { clienteId, datarefeicao, refeicaoId } = req.params;

    if (refeicaoId) {
        models.refeicao.update({ ...req.body, cliente: parseInt(clienteId), datarefeicao }, {
            where: {
                numsequencial: refeicaoId
            }
        })
            .then(() => {
                res.json({
                    sucesso: true
                });
            })
            .then(error => {
                res.json({
                    stack: error,
                    erros: [
                        "Erro ao tentar salvar refeição"
                    ]
                });
            });
    } else {
        models.refeicao.create({ ...req.body, cliente: clienteId, datarefeicao })
            .then(() => res.json({
                sucesso: true
            }))
            .then(error => res.json({
                stack: error,
                erros: [
                    "Erro ao tentar salvar refeição"
                ]
            }));
    }
});

module.exports = router;