$(function () {
    var viewModel = {
        vekt: ko.observable(null, { persist: 'vekt' }),
        stravaBrukernavn: ko.observable(null, { persist: 'stravaBrukernavn' }),
        sport: ko.observable(null, { persist: 'sport' }),
        timeZoneCorrection: ko.observable(null, { persist: 'timeZoneCorrection' })
    };
    
    ko.applyBindings(viewModel);
});
