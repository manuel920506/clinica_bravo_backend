namespace clinica_bravo_backend.DTOs {
    public class PaginationDTO
    {
        public int Page { get; set; } = 1;
        private int recordsForPage = 10;
        private readonly int maximumQuantityRecordsPerPage = 50;

        public int RecordsForPage {
            get
            {
                return recordsForPage;
            }
            set
            {
                recordsForPage = (value > maximumQuantityRecordsPerPage) ? maximumQuantityRecordsPerPage : value;
            }
        }
    }
}
