//$(function () {
//
//    fuelOptions = ['Biomass',
//        'Natural Gas',
//        'Compressed Natural Gas (CNG)',
//        'Liquefied Natural Gas (LNG)',
//        'Landfill Gas (LFG)',
//        'Oil',
//        'Heavy Fuel Oil (HFO)',
//        'Light Fuel Oil (LFO)',
//        'Jet Fuel',
//        'Residual Fuel Oil (RFO)',
//        'Distillate Fuel Oil (DFO)',
//        'Coal',
//        'Uranium'];
//
//    unitOptions = ['Base',
//        'Peaker'];
//
//
//    //include functionality to add fuel
//    $('#tech-capital-dynamic').unbind("click").on('click', '.btn-add', function (e) {
//        e.preventDefault();
//        console.log('add Generator');
//        var controlForm = $('#tech-capital-dynamic tbody tr:first');
//        addTechGen($(this), controlForm);
//    }).on('click', '.btn-remove', function (e) {
//        $(this).parents('.entry:first').remove();
//        e.preventDefault();
//        return false;
//    });
//
////Select options for thermal gen table
//	var $sel = $('#tech-capital-dynamic .unit-options');
//    updateTechSelection($sel, unitOptions);
//
//
//    var sel = $('#tech-capital-dynamic').find(".fuel-options");
//    updateTechSelection(sel,fuelOptions);
//    var option = sel.find("option");
//    for(var i = 0; i < sel.length;i++)
//    {
//       $(sel[i]).val($(option[i]).val());
//    }
//});
//
////update this logic
//function updateTechSelection(element, opts)
//{
//    element.empty();
//    for (var k = 0; k < opts.length; k++)
//    {
//         element.append('<option>' + opts[k] +'</option>');
//    }
//    return opts[opts.length - 1];
//
//}
//
//function addTechGen(element,controlForm) {
//    //console.log(element)
//    var currentEntry = element.parents('.entry:first');
//    var newEntry = $(currentEntry.clone()).appendTo(controlForm.parents('tbody'));
//
//    newEntry.find('input').val('0');
//    
//    newEntry.find('td span.remove-btn',element)
//        .html('<span class="input-group-btn"><a class="btn-remove btn btn-primary" type="button"><span class="glyphicon glyphicon-minus"></span></a></span>');
///*
//    currentEntry.find('td span .btn-add',element)
//        .removeClass('btn-add').addClass('btn-remove')
//        .removeClass('btn-primary').addClass('btn-default')
//        .html('<span class="glyphicon glyphicon-minus"></span>');
//*/
//    newEntry.find('.fuel-options',element).change(function () {
//        //console.log('test1111' + $(this).val());
//        console.log(fuelOptions[$(this).val()]);
//    })
//}
