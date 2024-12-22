namespace Todo.Core.ValueObjects
{
    public class Verification
    {
        public string Code { get;} = Guid.NewGuid().ToString("N")[0..6].ToUpper();
        public DateTime? ExpiresAt { get; private set; } = DateTime.UtcNow.AddMinutes(5);
        public DateTime? VerifiedAt { get; private set; } = null;
        public bool IsActive => VerifiedAt != null && ExpiresAt == null;
        public Verification()
        {
            
        }
        public void Verify(string code)
        {
            if (IsActive)
                throw new Exception("Esse token já foi ativado");

            if(ExpiresAt < DateTime.Now)
                throw new Exception("Esse código já expirou");

            if(!string.Equals(code.Trim(), Code.Trim(), StringComparison.CurrentCultureIgnoreCase))
                throw new Exception("Código inválido");

            ExpiresAt = null;
            VerifiedAt = DateTime.UtcNow;
        }
    }
}