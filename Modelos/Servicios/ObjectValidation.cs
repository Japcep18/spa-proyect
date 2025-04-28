using System.ComponentModel.DataAnnotations;

namespace Modelos.Servicios
{
    /// <summary>
    /// Valida los objetos según las restricciones definidas en las propiedades del mismo mediante Data Annotations
    /// </summary>
    public class ObjectValidation
    {
        private readonly ValidationContext context;
        private readonly List<ValidationResult> errors;
        private readonly bool valid;
        private readonly string message;

        /// <summary>
        /// Inicializa la validacicion del objeto
        /// </summary>
        /// <param name="instance">Objeto a validar</param>
        public ObjectValidation(object instance)
        {
            context = new(instance);
            errors = new List<ValidationResult>();
            valid = Validator.TryValidateObject(instance, context, errors, false);

            string msgacc = "";
            foreach (ValidationResult item in errors)
            {
                msgacc += $"{item.ErrorMessage}\n";
            }
            this.message = msgacc;
        }

        /// <summary>
        /// </summary>
        /// <returns>Retorna si la instancia es valida</returns>
        public bool IsValid()
        {
            return valid;
        }

        /// <summary>
        /// </summary>
        /// <returns>Retorna </returns>
        public string GetMessage()
        {
            return message;
        }
    }
}
