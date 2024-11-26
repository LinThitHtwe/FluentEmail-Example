﻿using FluentEmail.Example.Api.Models;
using FluentEmail.Example.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace FluentEmail.Example.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpGet("singleEmail")]
    public async Task<IActionResult> SendSingleEmail()
    {
        EmailMetadata emailMetadata = new(
            "linthit2745@gmail.com",
            "Testing Mail",
            "Just a test body",
            "Nothing"
        );

        await _emailService.Send(emailMetadata);

        return Ok();
    }

    [HttpGet("razorTemplateFromFile")]
    public async Task<IActionResult> SendEmailWithRazorTemplateFromFile()
    {
        var user = new User()
        {
            Name = "Lin Thit",
            Email = "linthit2745@gmail.com",
            MemberType = "Pro"
        };

        EmailMetadata emailMetadata = new(
           "linthit2745@gmail.com",
           "Testing Mail",
           "Just a test body",
           "Nothing"
       );

        var templateFile = $"{Directory.GetCurrentDirectory()}/EmailTemplate.cshtml";
        
        await _emailService.SendUsingTemplate(emailMetadata, user,templateFile);

        return Ok();
    }
}