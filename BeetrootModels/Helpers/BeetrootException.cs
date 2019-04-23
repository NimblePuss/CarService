using System;
using System.Net;
using BeetrootModels.Enums;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace BeetrootModels.Helpers
{
    public class BeetrootException : Exception
    {
        public ContentResult Result;
        private string errorMessage { get; set; }
        private HttpStatusCode statusCode { get; set; }

        public BeetrootException() : base() { }

        public BeetrootException(Error messege)
        {
            switch (messege)
            {
                case Error.UserNotAuthorized:
                    statusCode = HttpStatusCode.Unauthorized;
                    errorMessage = Error.UserNotAuthorized.ToString();
                    break;
                case Error.UserNotExist:
                    statusCode = HttpStatusCode.Unauthorized;
                    errorMessage = Error.UserNotExist.ToString();
                    break;
                case Error.UserNotRegister:
                    statusCode = HttpStatusCode.Unauthorized;
                    errorMessage = Error.UserNotRegister.ToString();
                    break;
                case Error.NotConfirm:
                    statusCode = HttpStatusCode.Unauthorized;
                    errorMessage = Error.NotConfirm.ToString();
                    break;
                case Error.UserExist:
                    statusCode = HttpStatusCode.BadRequest;
                    errorMessage = Error.UserExist.ToString();
                    break;
                case Error.EmptyData:
                    statusCode = HttpStatusCode.NoContent;
                    errorMessage = Error.EmptyData.ToString();
                    break;
                case Error.IncorrectEmailOrPassword:
                    statusCode = HttpStatusCode.Unauthorized;
                    errorMessage = Error.IncorrectEmailOrPassword.ToString();
                    break;
                case Error.PasswordNotMatch:
                    statusCode = HttpStatusCode.BadRequest;
                    errorMessage = Error.PasswordNotMatch.ToString();
                    break;
                case Error.DataNotFound:
                    statusCode = HttpStatusCode.NotFound;
                    errorMessage = Error.DataNotFound.ToString();
                    break;
                case Error.InternalServerError:
                    statusCode = HttpStatusCode.InternalServerError;
                    errorMessage = Error.InternalServerError.ToString();
                    break;
                case Error.AccessIsDenied:
                    statusCode = HttpStatusCode.Forbidden;
                    errorMessage = Error.AccessIsDenied.ToString();
                    break;
                case Error.Redirect:
                    statusCode = HttpStatusCode.Redirect;
                    errorMessage = Error.Redirect.ToString();
                    break;
                case Error.ServerIgnor:
                    statusCode = HttpStatusCode.ServiceUnavailable;
                    errorMessage = Error.ServerIgnor.ToString();
                    break;
                case Error.UploudFilesError:
                    statusCode = HttpStatusCode.BadRequest;
                    errorMessage = Error.UploudFilesError.ToString();
                    break;
                case Error.InvalidToken:
                    statusCode = HttpStatusCode.Unauthorized;
                    errorMessage = Error.InvalidToken.ToString();
                    break;
                case Error.UserBlocked:
                    statusCode = HttpStatusCode.Forbidden;
                    errorMessage = Error.UserBlocked.ToString();
                    break;
                case Error.DataExist:
                    statusCode = HttpStatusCode.BadRequest;
                    errorMessage = Error.DataExist.ToString();
                    break;
                case Error.SortFieldDoesntExist:
                    statusCode = HttpStatusCode.NotFound;
                    errorMessage = Error.SortFieldDoesntExist.ToString();
                    break;
                case Error.UpdateDataError:
                    statusCode = HttpStatusCode.BadRequest;
                    errorMessage = Error.UpdateDataError.ToString();
                    break;
                default:
                    statusCode = HttpStatusCode.BadRequest;
                    errorMessage = Error.SomethingWentWrong.ToString();
                    break;
            }

            Result = new ContentResult
            {
                StatusCode = (int)statusCode,
                Content = errorMessage
            };
        }
    }
}