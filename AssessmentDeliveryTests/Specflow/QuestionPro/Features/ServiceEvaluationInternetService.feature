Feature: ServiceEvaluationInternetService
	As an user
    I want to check Service Evaluation template for QuestionPro service

Background:
Given User navigates to Service Evaluation template

Scenario: TC1:Question contains answers after template view changing
	When User scrolls to table type question 'Rate the following aspects of your internet connection from'
	Then User provides answers
	| Aspect       | Excellent |
	| Speed        | Very Good |
	| Busy signals | Good      |
	| Disconnects  | Fair      |