using System;
using System.Web.Mvc;
using bdddoc.core;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;

namespace gorilla.mvc
{
    [Concern(typeof (Url))]
    public class when_building_a_url : observations_for_a_static_sut
    {
        it should_build_a_url_with_no_parameters =
            () => Url.To<TestController>(x => x.no_params()).should_be_equal_to(@"Test\no_params");

        it should_build_a_url_with_a_single_parameter =
            () => Url.To<TestController>(x => x.single_param("mo")).should_be_equal_to(@"Test\single_param?name=mo");

        it should_build_a_url_with_multiple_parameters =
            () => Url.To<TestController>(x => x.multiple_params(1001, "mo")).should_be_equal_to( @"Test\multiple_params?id=1001&name=mo");

        it should_be_able_to_build_a_url_by_picking_off_a_property_from_another_type =
            () => Url.To<TestController>(x => x.single_param(new {value = "chicken"}.value)).should_be_equal_to( @"Test\single_param?name=chicken");
    }

    class TestController : Controller
    {
        public void no_params()
        {
            throw new NotImplementedException();
        }

        public void single_param(string name)
        {
            throw new NotImplementedException();
        }

        public void multiple_params(int id, string name)
        {
            throw new NotImplementedException();
        }
    }
}