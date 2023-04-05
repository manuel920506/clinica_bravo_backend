using clinica_bravo_backend.Entities; 

namespace clinica_bravo_backend.Repositories
{
    public class RepositoryInMemory : IRepository
    {
        private List<Topic> _Topics;

        public RepositoryInMemory(ILogger<RepositoryInMemory> logger)
        {
            List<SubTopic> subtopic1 = new List<SubTopic>();
            subtopic1.Add(
                new SubTopic { 
                Id = 1,
                Name = "Síntomas de la hipertensión – Datos clave sobre la enfermedad",
                Description = "La hipertensión es una enfermedad que afecta a cerca del 40% de los adultos en América; es decir, alrededor de 250 millones de personas.\r\n\r\n\tDe esa cifra, 1.6 millones pierden la vida como consecuencia de esta enfermedad; la mayoría, tras contraer alguna enfermedad cardiovascular derivada de la hipertensión.\r\n\r\n\tLo preocupante de la situación, es que 500 mil de estos pacientes tienen menos de 70 años; es decir, la suya se considera una muerte prematura que, con el tratamiento adecuado, pudo haberse evitado.\r\n\r\n\tEsta es una enfermedad prevenible si se reconocen los síntomas y se toman las medidas necesarias, sigue leyendo para que descubras cuáles son dichos síntomas.",
                });
            subtopic1.Add(
               new SubTopic {
                   Id = 2,
                   Name = "Síntomas de la hipertensión",
                   Description = "\tEn la mayoría de los casos, el único síntoma de la hipertensión es la presión arterial alta; más allá de eso, hay muchos pacientes que no presentan ningún otro sigo.\r\n\r\n\tSin embargo, hay algunas personas que muestran:\r\n\r\n\tDolor de cabeza.\r\n\tDificultad para respirar.\r\n\tSangrado nasal.\r\n\tEl lado negativo es que estos pueden ser síntomas de muchas otras cosas y, por lo general, el paciente no sabe que padece hipertensión hasta que la enfermedad alcanza niveles peligrosamente altos.",
               });
            subtopic1.Add(
               new SubTopic {
                   Id = 3,
                   Name = "¿Cómo controlar la hipertensión?",
                   Description = "Los síntomas de la hipertensión se pueden controlar con intervenciones preventivas como:\r\n\r\n\tDisminuir el consumo de sal.\r\n\tComer frutas y verduras.\r\n\tHacer ejercicio.\r\n\tMantener un peso saludable.\r\n\tEs decir, el secreto para controlar la hipertensión es comer bien y mantener un estilo de vida activo.",
               });
            subtopic1.Add(
               new SubTopic {
                   Id = 4,
                   Name = "Aspectos clave de la hipertensión",
                   Description = "Además de los síntomas de la hipertensión, existen otros aspectos importantes a tomar en cuenta para saber si sufres o no de esta enfermedad; tales como:\r\n\r\n\tHipertensión es cuando tu presión es igual o superior a 140/90 mmHg.\r\n\tLas personas hipertensas están en la primera línea de riesgo de padecer enfermedades cardiovasculares.\r\n\tLas enfermedades cardiovasculares provocan el 30% de las muertes en la región americana.\r\n\r\n\tLa hipertensión es consecuencia de un consumo alto de sal y bajo de frutas y vegetales; así como de la ingesta desmedida de alcohol y del sedentarismo.\r\n\tSi combinas tabaco, obesidad, diabetes y problemas de colesterol con hipertensión, aumentas el riesgo de padecer alguna enfermedad cardiovascular.\r\n\tEntre 30% y 48% de la población de América sufre de presión arterial alta.\r\n\tSegún la Organización Panamericana de la Salud, las personas de bajos recursos son los más propensos a desarrollar enfermedades cardíacas y sufrir accidentes cerebrovasculares; sumémosle a eso que tienen menos acceso a tratamientos preventivos y medicamentos.\r\n\tEste es un tema importante a tomar en cuenta; ya que, el alto costo de la vida, sumado al precio de los servicios de salud que requiere un paciente con hipertensión, hacen que cada vez más personas caigan en la pobreza.\r\n\r\n\tEsta es una realidad de millones de personas.\r\n\r\n\tLa mejor forma de evitar la hipertensión es reducir el consumo de sal.\r\n\tAdemás de esto, es importante combinar tu dieta baja en sal con una reducción considerable del consumo de tabaco.\r\n\r\n\tDe hacer caso a estas indicaciones, la OPS estima que en los próximos 10 años se podrían prevenir 3.5 millones de muerte en América.",
               });

            List<SubTopic> subtopic2 = new List<SubTopic>();
            subtopic2.Add(
                new SubTopic {
                    Id = 5,
                    Name = "CAUSAS de la DIABETES ¿Cómo saber si tengo la enfermedad?",
                    Description = "¿Conoces las causas de la diabetes? Además de la genética y la obesidad, esta enfermedad puede aparecer por diversas razones; así que, si no quieres que te tome por sorpresa infórmate y mantente atento a las señales de tu cuerpo.\r\n\r\n\tSigue leyendo y descubre cuáles son esas señales.",
                });
            subtopic2.Add(
               new SubTopic {
                   Id = 6,
                   Name = "Síntomas de la diabetes",
                   Description = "\tMuchas personas no saben que padecen diabetes hasta que aparecen los problemas de salud graves, tales como úlceras, pérdida de peso o problemas cardíacos, entre otros.\r\n\r\n\tEn líneas generales, los síntomas son:\r\n\r\n\tAumento de la sed y el apetito.\r\n\tAumento de ganas de orinar.\r\n\tFatiga.\r\n\tHeridas que no cicatrizan.\r\n\tHormigueo de las articulaciones.\r\n\tPérdida repentina de peso.\r\n\tVisión borrosa.\r\n\tLa diferencia entre diabetes tipo 1 y 2 es cuándo aparecen los síntomas; ya que, en la primera se presentan de golpe, mientras que segunda surgen de forma progresiva y, en muchos casos, de manera silenciosa.",
               });
            subtopic2.Add(
               new SubTopic {
                   Id = 7,
                   Name = "Causas de la diabetes tipo 1",
                   Description = "Esta variante de la enfermedad aparece cuando el sistema inmunitario atenta contra las células beta del páncreas y perjudica la producción de insulina.\r\n\r\n\tSe cree que la diabetes tipo 1 es consecuencia factores genéticos y/o ambientales; es decir, antecedentes familiares o algún virus que desencadene los síntomas ya mencionados.",
               });
            subtopic2.Add(
               new SubTopic {
                   Id = 8,
                   Name = "Causas de la diabetes tipo 2",
                   Description = "Esta es la forma más común de la enfermedad y, por lo mismo, es consecuencia de diferentes factores como tu régimen alimenticio o la genética.\r\n\r\n\tEntre esos factores tenemos:\r\n\t\r\n\tSobrepeso y sedentarismo\r\n\tLa obesidad y la falta de actividad física son dos de las principales causas de la diabetes; ya que, muchas veces, el peso extra provoca resistencia a la insulina, dando pie a la aparición de la diabetes tipo 2.\r\n\r\n\tEn ese caso influye mucho dónde se concentra el exceso de grasa, siendo en el vientre la ubicación más peligrosa; ya que, compromete el corazón y los vasos sanguíneos.\r\n\r\n\tResistencia a la insulina  \r\n\tLa diabetes es consecuencia de la resistencia de la insulina; lo cual se produce cuando el páncreas no produce suficiente de esta hormona y la que sí se produce es mal utilizada por los músculos, el hígado y las células grasas.\r\n\r\n\tLa insulina es fundamental para darle paso a la glucosa o, de lo contrario, aumenta la azúcar en sangre, causando graves daños a la salud.\r\n\r\n\tHistorial familiar\r\n\tSi en tu familia existen antecedentes de diabetes hay una posibilidad que, en algún momento, tú también la padezcas.\r\n\r\n\tEstamos hablando de una enfermedad con factores hereditarios que aparece con más frecuencia en los grupos:\r\n\r\n\tAfroamericanos.\r\n\tAsiático-estadounidenses.\r\n\tHawaianos.\r\n\tHispanos.\r\n\tIndígenas estadounidenses.\r\n\tNativos de Alaska.\r\n\tNativos de las Islas del Pacífico.\r\n\t¡Cuídate! Ven a consulta periódica y no dejes que la enfermedad te tome por sorpresa",
               });

            _Topics = new List<Topic>()
            {
                new Topic(){Id = 1, Name = "Síntomas de la hipertensión – Datos clave sobre la enfermedad", SubTopics = subtopic1},
                new Topic(){Id = 2, Name = "CAUSAS de la DIABETES ¿Cómo saber si tengo la enfermedad?", SubTopics = subtopic2}
            }; 

            _guid = Guid.NewGuid(); // 123456-DFKSLDF-SLK3M4324-DSADALKSKDM
        }
        public Guid _guid;

        public List<Topic> GetAllTopics()
        {
            return _Topics;
        }

        public async Task<Topic> GetById(int Id)
        {
            await Task.Delay(1);

            return _Topics.FirstOrDefault(x => x.Id == Id);
        }

        public Guid GetGUID()
        {
            return _guid;
        }

        public void CreateTopic(Topic genero)
        {
            genero.Id = _Topics.Count() + 1;
            _Topics.Add(genero);
        }
    }
}
