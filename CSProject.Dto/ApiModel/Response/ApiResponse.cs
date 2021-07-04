namespace CSProject.Dto.ApiModel.Response
{
    public class ApiResponse<T> where T : class
    {
        public string Status { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}
