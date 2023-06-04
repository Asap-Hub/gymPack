﻿using gym.Application.Extentions.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace gym.Application.Commands.AccountUser.Requests
{
    public class signUserOutCommand : IRequest<BaseResponse>
    {
        public string Email { get; set; }
    }
}
