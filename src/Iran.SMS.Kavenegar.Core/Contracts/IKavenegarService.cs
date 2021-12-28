using System.Threading.Tasks;
using Iran.SMS.Kavenegar.Core.Models;

namespace Iran.SMS.Kavenegar.Core {

    /// <summary>
    /// Kavenegar API provider
    /// </summary>
    public interface IKavenegarService {

        /// <summary>
        /// Send single message to a group of receptors (<see cref="MobileNumber"/>s).
        /// </summary>
        /// <typeparam name="T">type of Local Id (Local means the entity that save message history in database)</typeparam>
        /// <param name="model">Pass input as <see cref="SendSmsInput{T}"/></param>
        /// <returns></returns>
        Task<SendSmsOutput> SendAsync<T>(SendSmsInput<T> model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<VerifySmsOutput> VerifyAsync(VerifySmsInput model);

    }
}
