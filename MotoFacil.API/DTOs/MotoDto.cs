using MotoFacil.Domain.Entities;

namespace MotoFacil.DTOs
{
    public class MotoDto
    {
        // O ID não precisa ser incluído se ele não for usado para criação/atualização diretamente
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Chassi { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }

        public Moto ToEntity()
        {
            var moto = new Moto
            {
                Modelo = this.Modelo,
                Placa = this.Placa,
                Chassi = this.Chassi,
                Status = this.Status
            };

            moto.SetUserId(this.UserId); // Usa método público para atribuir userId
            return moto;
        }
    }
}
