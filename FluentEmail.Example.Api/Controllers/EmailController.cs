using FluentEmail.Example.Models;
using FluentEmail.Example.Services.Features.SendMail;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FluentEmail.Example.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly SendMailService _sendMailService;

    public EmailController(SendMailService sendMailService)
    {
        _sendMailService = sendMailService;
    }

    [HttpGet("singleEmail")]
    public async Task<IActionResult> SendSingleEmail()
    {
        EmailRequestModel emailRequestModel = new()
        {
            ToEmail = "linthit2745@gmail.com",
            Subject="Test",
            Body = "TestBody",
            IsUseTemplate = true,
            //CC = ["linthithtwe@outlook.com"]
        };

        await _sendMailService.Send(emailRequestModel);

        return Ok();
    }

    [HttpPost("SendMail")]
    public async Task<IActionResult> SendMail([FromBody] EmailRequestModel emailRequestModel)
    {

        try
        {
            await _sendMailService.Send(emailRequestModel);
            return Ok();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("SendMailWithTemplate")]
    public async Task<IActionResult> SendMailWithTemplate([FromBody] EmailRequestModel emailRequestModel)
    {

        try
        {
            await _sendMailService.Send(emailRequestModel);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }



    //[HttpGet("razorTemplateFromFile")]
    //public async Task<IActionResult> SendEmailWithRazorTemplateFromFile()
    //{
    //    var user = new User()
    //    {
    //        Name = "Lin Thit",
    //        Email = "linthit2745@gmail.com",
    //        MemberType = "Pro"
    //    };

    //    EmailMetadata emailMetadata = new(
    //       "linthit2745@gmail.com",
    //       "Testing Mail",
    //       "Just a test body",
    //       "Nothing"
    //    );

    //    var templateFile = $"{Directory.GetCurrentDirectory()}/EmailTemplate.cshtml";

    //    await _emailService.SendUsingTemplate(emailMetadata, user, templateFile);

    //    return Ok();
    //}

    //[HttpGet("withAttachment")]
    //public async Task<IActionResult> SendEmailWithAttachment()
    //{
    //    EmailMetadata emailMetadata = new(
    //       "linthit2745@gmail.com",
    //       "Testing Mail with attachment",
    //       "Just a test body",
    //       $"{Directory.GetCurrentDirectory()}/Test.txt"
    //    );

    //    await _emailService.SendWithAttachment(emailMetadata);

    //    return Ok();
    //}

    //[HttpGet("multipleEmails")]
    //public async Task<IActionResult> SendMultipleEmails()
    //{
    //    List<User> users =
    //    [
    //        new User()
    //        {
    //            Email = "linthithtwe@gmail.com",
    //             Name = "LinThitHtwe",
    //             MemberType = "Pro"
    //        },
    //        new User()
    //        {
    //            Email = "htwe@gmail.com",
    //             Name = "Htwe",
    //             MemberType = "Basic"
    //        }
    //    ];

    //    List<EmailMetadata> emailMetadatas = new();

    //    foreach(var user in users)
    //    {
    //        EmailMetadata emailMetadata = new
    //            (user.Email, "Multiple Email","Body","None");
    //        emailMetadatas.Add(emailMetadata);
    //    }

    //    await _emailService.SendMultiple(emailMetadatas);

    //    return Ok();
    //}

    //[HttpPost]
    //public async Task<IActionResult> SendEmailPost(EmailMetadata emailMetadata)
    //{
    //    await _emailService.Send(emailMetadata);

    //    return Ok();
    //}
}
