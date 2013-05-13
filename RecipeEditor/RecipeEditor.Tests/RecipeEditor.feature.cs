﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18033
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace RecipeEditor.Tests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class RecipeEditorFeature : Xunit.IUseFixture<RecipeEditorFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "RecipeEditor.feature"
#line hidden
        
        public RecipeEditorFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "RecipeEditor", "In order to edit a recipe\r\nAs a registered user\r\nI want to be able to modify all " +
                    "properties of a recipe", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void SetFixture(RecipeEditorFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "RecipeEditor")]
        [Xunit.TraitAttribute("Description", "Show View")]
        public virtual void ShowView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Show View", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I am on the \"Streuselkuchen\" recipe page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.Then("I should be in view mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "RecipeEditor")]
        [Xunit.TraitAttribute("Description", "Show Editor")]
        public virtual void ShowEditor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Show Editor", ((string[])(null)));
#line 10
this.ScenarioSetup(scenarioInfo);
#line 11
 testRunner.Given("I am on the \"Streuselkuchen\" recipe page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 12
 testRunner.When("I click on the \"bearbeiten\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.Then("I should be in edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "RecipeEditor")]
        [Xunit.TraitAttribute("Description", "Show Preview")]
        public virtual void ShowPreview()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Show Preview", ((string[])(null)));
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
 testRunner.Given("I am on the \"Streuselkuchen\" recipe page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
 testRunner.And("I am in edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.When("I click on the \"vorschau\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
 testRunner.Then("I should be in preview mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "RecipeEditor")]
        [Xunit.TraitAttribute("Description", "Edit Title")]
        public virtual void EditTitle()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Edit Title", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
 testRunner.Given("I am on the \"Streuselkuchen\" recipe page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
 testRunner.And("I am in edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.When("I click on the title", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
 testRunner.And("I clear the text", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("I type \"Kirschstreusel\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.Then("the title should be \"Kirschstreusel\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "RecipeEditor")]
        [Xunit.TraitAttribute("Description", "Edit Component Title")]
        public virtual void EditComponentTitle()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Edit Component Title", ((string[])(null)));
#line 29
this.ScenarioSetup(scenarioInfo);
#line 30
 testRunner.Given("I am on the \"Streuselkuchen\" recipe page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
 testRunner.And("I am in edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.When("I click on the first preparation component title", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
 testRunner.And("I clear the text", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And("I type \"Kuchenteig\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.Then("the title of the first component should be \"Kuchenteig\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "RecipeEditor")]
        [Xunit.TraitAttribute("Description", "Edit Component Preparation")]
        public virtual void EditComponentPreparation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Edit Component Preparation", new string[] {
                        "NoPhantomJs"});
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
 testRunner.Given("I am on the \"Streuselkuchen\" recipe page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
 testRunner.And("I am in edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.When("I click on the first preparation text", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
 testRunner.And("I clear the text", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.And("I type \"Alles verrühren\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.Then("the preparation of the first component should be \"Alles verrühren\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "RecipeEditor")]
        [Xunit.TraitAttribute("Description", "Add Component")]
        public virtual void AddComponent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Component", ((string[])(null)));
#line 46
this.ScenarioSetup(scenarioInfo);
#line 47
 testRunner.Given("I am on the \"Streuselkuchen\" recipe page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 48
 testRunner.And("I am in edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.When("I click on the add component button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
 testRunner.Then("there should be 3 components", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
 testRunner.And("the title of the third component should be \"neu\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "RecipeEditor")]
        [Xunit.TraitAttribute("Description", "Remove Component")]
        public virtual void RemoveComponent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Remove Component", ((string[])(null)));
#line 53
this.ScenarioSetup(scenarioInfo);
#line 54
 testRunner.Given("I am on the \"Streuselkuchen\" recipe page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 55
 testRunner.And("I am in edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.When("I click on the first remove component button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
 testRunner.Then("there should be 1 components", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 58
 testRunner.And("the title of the first component should be \"Streusel\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "RecipeEditor")]
        [Xunit.TraitAttribute("Description", "Add Category")]
        public virtual void AddCategory()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Category", ((string[])(null)));
#line 60
this.ScenarioSetup(scenarioInfo);
#line 61
 testRunner.Given("I am on the \"Streuselkuchen\" recipe page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 62
 testRunner.And("I am in edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.When("I click on the empty category field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 64
 testRunner.And("I type \"Blechkuchen\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.Then("there should be 3 categories", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
 testRunner.And("the title of the third category should be \"Blechkuchen\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "RecipeEditor")]
        [Xunit.TraitAttribute("Description", "Dynamically Add Category Fields")]
        public virtual void DynamicallyAddCategoryFields()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dynamically Add Category Fields", ((string[])(null)));
#line 68
this.ScenarioSetup(scenarioInfo);
#line 69
 testRunner.Given("I am on the \"Streuselkuchen\" recipe page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 70
 testRunner.And("I am in edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
 testRunner.When("I click on the empty category field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 72
 testRunner.And("I type \"Blechkuchen\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.Then("there should be 4 category fields", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 74
 testRunner.And("there should be an empty category field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "RecipeEditor")]
        [Xunit.TraitAttribute("Description", "Remove Category")]
        public virtual void RemoveCategory()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Remove Category", ((string[])(null)));
#line 76
this.ScenarioSetup(scenarioInfo);
#line 77
 testRunner.Given("I am on the \"Streuselkuchen\" recipe page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 78
 testRunner.And("I am in edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.When("I click on the first category field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 80
 testRunner.And("I clear the text", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.Then("there should be 1 categories", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 82
 testRunner.And("the title of the first category should be \"Kleingebäck\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "RecipeEditor")]
        [Xunit.TraitAttribute("Description", "Add Ingredient to new Component")]
        public virtual void AddIngredientToNewComponent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Ingredient to new Component", ((string[])(null)));
#line 84
this.ScenarioSetup(scenarioInfo);
#line 85
 testRunner.Given("I am on the \"Streuselkuchen\" recipe page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 86
 testRunner.And("I am in edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
 testRunner.When("I click on the add component button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 88
 testRunner.And("I set the empty ingredient field of the component \"neu\" to 30 ml Wasser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.Then("the component \"neu\" should contain 30 ml Wasser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "RecipeEditor")]
        [Xunit.TraitAttribute("Description", "Add Ingredient to existing Component")]
        public virtual void AddIngredientToExistingComponent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Ingredient to existing Component", ((string[])(null)));
#line 91
this.ScenarioSetup(scenarioInfo);
#line 92
 testRunner.Given("I am on the \"Streuselkuchen\" recipe page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 93
 testRunner.And("I am in edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.When("I set the empty ingredient field of the component \"Teig\" to 30 ml Wasser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 95
 testRunner.Then("the component \"Teig\" should contain 30 ml Wasser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "RecipeEditor")]
        [Xunit.TraitAttribute("Description", "Dynamically Add Ingredient Fields")]
        public virtual void DynamicallyAddIngredientFields()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dynamically Add Ingredient Fields", ((string[])(null)));
#line 97
this.ScenarioSetup(scenarioInfo);
#line 98
 testRunner.Given("I am on the \"Streuselkuchen\" recipe page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 99
 testRunner.And("I am in edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.When("I set the empty ingredient field of the component \"Teig\" to 30 ml Wasser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 101
 testRunner.Then("there should be 9 ingredient fields in the component \"Teig\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 102
 testRunner.Then("there should be an empty ingredient field in the component \"Teig\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "RecipeEditor")]
        [Xunit.TraitAttribute("Description", "Remove Ingredient from Component")]
        public virtual void RemoveIngredientFromComponent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Remove Ingredient from Component", ((string[])(null)));
#line 104
this.ScenarioSetup(scenarioInfo);
#line 105
 testRunner.Given("I am on the \"Streuselkuchen\" recipe page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 106
 testRunner.And("I am in edit mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
 testRunner.When("I clear the second ingredient field of the component \"Teig\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 108
 testRunner.Then("the component \"Teig\" should not contain Margarine", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                RecipeEditorFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                RecipeEditorFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
