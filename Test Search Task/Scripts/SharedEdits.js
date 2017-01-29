$(function () {

    // disable NewReleaseComingSoon & NewReleaseWithinPastMonth when the correct value for RelaseDate is being inserted 
    $("#ReleaseDate").on('change',function () {
        CheckReleaseDate();
    });

    $("#NewReleaseComingSoon").on('change', function () {
        CheckNewReleaseComingSoon();
    });

    $("#NewReleaseWithinPastMonth").on('change', function () {
        CheckNewReleaseWithinPastMonth();
    });

    function CheckReleaseDate() {
        var ReleaseDate = $("#ReleaseDate").val();

        if (ReleaseDate != null) {
            $('#NewReleaseComingSoon').val('');
            $('#NewReleaseWithinPastMonth').val('');
            $('#NewReleaseComingSoon').prop('disabled', function (i, v) { return !v; });
            $('#NewReleaseWithinPastMonth').prop('disabled', function (i, v) { return !v; });
           
        }
    }

    function CheckNewReleaseComingSoon() {
        var NewReleaseComingSoon = $("#NewReleaseComingSoon").val();

        if (NewReleaseComingSoon != null) {
            $('#ReleaseDate').prop('disabled', function (i, v) { return !v; });
            $('#NewReleaseWithinPastMonth').prop('disabled', function (i, v) { return !v; });
        }
    }

    function CheckNewReleaseWithinPastMonth() {
        var NewReleaseWithinPastMonth = $("#NewReleaseWithinPastMonth").val();

        if (NewReleaseWithinPastMonth != null) {
            $('#ReleaseDate').prop('disabled', function (i, v) { return !v; });
            $('#NewReleaseComingSoon').prop('disabled', function (i, v) { return !v; });
        }
    }
})