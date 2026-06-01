-- =============================================
-- Fill the tags below using Ctrl + Shift + M
--
-- Student ID: 11123622
-- Student Name: Jorge Louro
-- Test Date: 14/06/24
--
-- =============================================

--Answers:

-- 4) 
SELECT *
FROM Curso
ORDER BY NomeCurso;

-- 5)
SELECT *
FROM Instituicao
ORDER BY CodInstituicao;

-- 6)
SELECT Bolsa.*, Parecer.Resultado
FROM Bolsa
JOIN Parecer ON Bolsa.NumCandidato = Parecer.NumCandidato
AND Bolsa.CodCurso = Parecer.CodCurso
AND Bolsa.CodInstituicao = Parecer.CodInstituicao;

-- 7)
SELECT DISTINCT Instituicao.NomeInstituicao
FROM Bolsa
JOIN Instituicao ON Bolsa.CodInstituicao = Instituicao.CodInstituicao
WHERE Bolsa.DataInicioPagamento < '2023-09-01';

-- 8)
SELECT Bolsa.* FROM BOLSA
INNER JOIN Candidato ON Bolsa.NumCandidato = Candidato.NumCandidato
INNER JOIN Nacionalidade ON Candidato.CodNacionalidade = Nacionalidade.CodNacionalidade
WHERE Nacionalidade.Nacionalidade = 'Espanhol'

-- 9)
SELECT
Candidato.NomeCandidato,
Candidato.Morada,
CodPostal.Localidade | ', ' | CodPostal.CodPostal AS CodigoPostalCompleto,
Profissao.Designacao,
Nacionalidade.Nacionalidade,
Curso.NomeCurso,
 
Instituicao.NomeInstituicao,
Bolsa.ValorBolsa,
Bolsa.NumPrestacoes,
COUNT(Parecer.NumParecer) AS QuantidadePareceres,
Bolsa.DataInicioPagamento
FROM Candidato
LEFT JOIN CodPostal ON Candidato.CodPostal = CodPostal.CodPostal
LEFT JOIN Profissao ON Candidato.CodProfissao = Profissao.CodProfissao
LEFT JOIN Nacionalidade ON Candidato.CodNacionalidade = Nacionalidade.CodNacionalidade
LEFT JOIN Bolsa ON Candidato.NumCandidato = Bolsa.NumCandidato
LEFT JOIN Curso ON Bolsa.CodCurso = Curso.CodCurso
LEFT JOIN Instituicao ON Bolsa.CodInstituicao = Instituicao.CodInstituicao
LEFT JOIN Parecer ON Candidato.NumCandidato = Parecer.NumCandidato
AND Bolsa.CodCurso = Parecer.CodCurso
AND Bolsa.CodInstituicao = Parecer.CodInstituicao
GROUP BY
Candidato.NomeCandidato,
Candidato.Morada,
CodPostal.Localidade,
CodPostal.CodPostal,
Profissao.Designacao,
Nacionalidade.Nacionalidade,
Curso.NomeCurso,
Instituicao.NomeInstituicao,
Bolsa.ValorBolsa,
Bolsa.NumPrestacoes,
Bolsa.DataInicioPagamento;
