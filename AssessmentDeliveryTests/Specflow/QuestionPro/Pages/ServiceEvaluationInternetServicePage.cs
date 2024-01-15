﻿using AssessmentDeliveryTestingFramework.Core.Session;
using AssessmentDeliveryTestingFramework.Core.Wait;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionProTests.Pages
{
    internal class ServiceEvaluationInternetServicePage
    {
        private readonly WebSession _session;

        private IList<IWebElement> _QuestionElementList => _session.WebElementWaiting.WaitElements(By.XPath("//div[@id='desktop']//div[contains(@id, 'QuestionSection')]"));

        public ServiceEvaluationInternetServicePage(WebSession session) 
        {
            _session = session;
        }

        public void GetElementByQuestion(string questionText, out IWebElement questionContainerElement, out IWebElement questionTitleElement)
        {
            foreach (var el in _QuestionElementList)
            {
                var tempQuestionTitleElement = el.FindElement(By.ClassName("question-text-span"));

                if (tempQuestionTitleElement.Text.Contains(questionText))
                {
                    questionContainerElement = el;

                    questionTitleElement = tempQuestionTitleElement;
                }
            }

            throw new NoSuchElementException($"Element with question '{questionText}' was not found.");
        }
    }
}
