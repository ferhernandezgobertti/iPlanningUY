using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    
    public class Signature {

        [Key]
        public int SignatureID { get; set; }
        public DateTime FirstSigning { get; set; }
        public virtual Architect FirstSigner { get; set; }
        public DateTime SecondSigning { get; set; }
        public Architect SecondSigner;

        public Signature()
        {

        }

        public Signature(Architect oneSigner) {
            this.FirstSigning = DateTime.Now;
            this.FirstSigner = oneSigner;
            this.SecondSigner = null;
        }

        public bool IsOnlyOneSigner() {
            return this.SecondSigner == null;
        }

        public void RegisterSecondSignature(Architect secondSigner)
        {
            this.SecondSigning = DateTime.Now;
            this.SecondSigner = secondSigner;
        }

        public override string ToString()
        {
            StringBuilder signaturePresentation = new StringBuilder();
            signaturePresentation.Append(" - 1st Signature: ");
            signaturePresentation.Append(this.FirstSigner.UserName);
            signaturePresentation.Append(" at ");
            signaturePresentation.Append(this.FirstSigning.ToString());
            if (!this.IsOnlyOneSigner()) {
                signaturePresentation.Append(" - 2nd Signature: ");
                signaturePresentation.Append(this.SecondSigner.UserName);
                signaturePresentation.Append(" at ");
                signaturePresentation.Append(this.SecondSigning.ToString());
            }
            return signaturePresentation.ToString();
        }

        public override bool Equals(object anObject)
        {
            Signature aSignature = anObject as Signature;

            if (aSignature == null)
                return false;

            if (!this.IsOnlyOneSigner()) {
                return this.FirstSigner.Equals(aSignature.FirstSigner) && this.FirstSigning.Equals(aSignature.FirstSigning) 
                    && this.SecondSigner.Equals(aSignature.SecondSigner) && this.SecondSigning.Equals(aSignature.SecondSigning);
            } else {
                return this.FirstSigner.Equals(aSignature.FirstSigner) && this.FirstSigning.Equals(aSignature.FirstSigning);
            }
        }

    }
}
