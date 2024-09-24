using Api_Funcionario.DTO;
using Api_Funcionario.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Funcionario.Controllers
{
    [Route("funcionarios")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        List<Funcionario> listaFuncionario = new List<Funcionario>();

        public FuncionarioController()
        {
            var funcionario1 = new Funcionario()
            {
                Id = 1,
                Nome = "Renato",
                CPF = "026.662.922-90",
                CTPS = "32783287325897",
                RG = "1692493",
                Funcao = "Gerente",
                Setor = "Administrativo",
                Sala = "209B",
                Telefone = "(69) 99606-8551",
                UF = "RO",
                Cidade = "Ji-Paraná",
                Bairro = "Araçá",
                Numero = 178,
                CEP = 76906376
            };

            listaFuncionario.Add(funcionario1);
        }

        [HttpGet] 
        public IActionResult Get()
        {
            return Ok(listaFuncionario);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var funcionario = listaFuncionario.Where(item => item.Id == id).FirstOrDefault();

            if (funcionario == null)
            {
                return NotFound();
            }

            return Ok(funcionario);
        }
        [HttpPost] 
        public IActionResult Post([FromBody] FuncionarioDTO item)
        {
            var contador = listaFuncionario.Count();

            var funcionario = new Funcionario();

            funcionario.Id = contador + 1;
            funcionario.Nome = item.Nome;
            funcionario.CPF = item.CPF;
            funcionario.CTPS = item.CTPS;
            funcionario.RG = item.RG;
            funcionario.Funcao = item.Funcao;
            funcionario.Setor = item.Setor;
            funcionario.Sala = item.Sala;
            funcionario.Telefone = item.Telefone;
            funcionario.UF = item.UF;
            funcionario.Cidade = item.Cidade;
            funcionario.Bairro = item.Bairro;
            funcionario.Numero = item.Numero;
            funcionario.CEP = item.CEP;
            
            listaFuncionario.Add(funcionario);

            return StatusCode(StatusCodes.Status201Created, funcionario);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] FuncionarioDTO item)
        {
            var funcionario = listaFuncionario.Where(item => item.Id == id).FirstOrDefault();

            if (funcionario == null)
            {
                return NotFound();
            }

            funcionario.Nome = item.Nome;
            funcionario.CPF = item.CPF;
            funcionario.CTPS = item.CTPS;
            funcionario.RG = item.RG;
            funcionario.Funcao = item.Funcao;
            funcionario.Setor = item.Setor;
            funcionario.Sala = item.Sala;
            funcionario.Telefone = item.Telefone;
            funcionario.UF = item.UF;
            funcionario.Cidade = item.Cidade;
            funcionario.Bairro = item.Bairro;
            funcionario.Numero = item.Numero;
            funcionario.CEP = item.CEP;

            return Ok(funcionario);
        }

        [HttpDelete("{id}")] 
        public IActionResult Delete(int id)
        {
            var funcionario = listaFuncionario.Where(item => item.Id == id).FirstOrDefault();

            if (funcionario == null) 
            {
                return NotFound();
            }

            listaFuncionario.Remove(funcionario);

            return Ok(funcionario); 
        }
    }
}
