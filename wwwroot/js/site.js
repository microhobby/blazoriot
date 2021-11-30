
function setDonut3 (val) {
    if (val > 80)
        LDRLevelColor = "#fff200";
    else if (val > 55)
        LDRLevelColor = "#e3be29";
    else if (val > 45)
        LDRLevelColor = "#c98f1a";
    else
        LDRLevelColor = "#c9571a";
    
    $(".donut-fill").attr("stroke", LDRLevelColor);
    let donut = $('#donut3').data('donut');
    donut.val(val);
}
