var OhmCalc = {};

OhmCalc.controller = {
    ddBandA_sel: '#BandAColor',
    ddBandB_sel: '#BandBColor',
    ddBandC_sel: '#BandCColor',
    ddBandD_sel: '#BandDColor',
    divOhmResults_sel: '#ohmResults',
    btnCalculate_sel: '#btnCalculate',
    btnReset_sel: '#btnReset',
    ohmResultOutput_sel: '#ohmResultOutput',
    ohmCalculateValidationMessage_sel: '#ohmCalculateValidationMessage',

    // Function definitions
    CalculateOhmValue: function () {
        var inputsValid = this.ValidateInputs();
        if (inputsValid !== true) return;
        var action_url = '/Home/Calculate';
        $.ajax({
            url: action_url,
            data: {
                bandAColor: $(this.ddBandA_sel).val(),
                bandBColor: $(this.ddBandB_sel).val(),
                bandCColor: $(this.ddBandC_sel).val(),
                bandDColor: $(this.ddBandD_sel).val()
            },
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data !== null && data.Success !== undefined && data.Success === true && data.Data !== null) {
                    $(ctrl.ohmResultOutput_sel).html(data.Data);
                } else {
                    $(ctrl.ohmResultOutput_sel).html('');
                }
            }
        });
    },

    ValidateInputs: function () {
        var result = true;
        var bandAColor = $(this.ddBandA_sel).val();
        var bandBColor = $(this.ddBandB_sel).val();
        var bandCColor = $(this.ddBandC_sel).val();
        this.DropDownSelectionChange(null);
        if (bandAColor === null || bandAColor === '' ||
            bandBColor === null || bandBColor === '' ||
            bandCColor === null || bandCColor === '') {
            result = false;
        }
        return result;
    },

    AddBorderValidation: function (sel) {
        var elem = $(sel);
        if (elem !== null) elem.addClass('value_required_border');
    },

    RemoveBorderValidation: function (sel) {
        var elem = $(sel);
        if (elem !== null) elem.removeClass('value_required_border');
    },

    ResetInputs: function () {
        $(this.ohmCalculateValidationMessage_sel).fadeOut();
        $(this.ddBandA_sel).val(null);
        $(this.ddBandB_sel).val(null);
        $(this.ddBandC_sel).val(null);
        $(this.ddBandD_sel).val(null);
        $(this.ohmResultOutput_sel).html('');
        this.RemoveBorderValidation(this.ddBandA_sel);
        this.RemoveBorderValidation(this.ddBandB_sel);
        this.RemoveBorderValidation(this.ddBandC_sel);
        $(this.ohmCalculateValidationMessage_sel).html('');
    },

    DropDownSelectionChange: function (dropdown) {
        var errmsg = '';
        var bandA_val = $(this.ddBandA_sel).val();
        var bandB_val = $(this.ddBandB_sel).val();
        var bandC_val = $(this.ddBandC_sel).val();
        if (dropdown !== null) {
            switch ('#' + dropdown.id) {
                case this.ddBandA_sel:
                    if (dropdown.value === null || dropdown.value === '') {
                        this.AddBorderValidation(this.ddBandA_sel);
                        errmsg += "Color selection required for Band A<br/>";
                    }
                    else {
                        this.RemoveBorderValidation(this.ddBandA_sel);
                    }
                    break;
                case this.ddBandB_sel:
                    if (bandA_val === null || bandA_val === '') {
                        errmsg += "Color selection required for Band A<br/>";
                        this.AddBorderValidation(this.ddBandA_sel);
                    }
                    if (dropdown.value === null || dropdown.value === '') {
                        errmsg += "Color selection required for Band B<br/>";
                        this.AddBorderValidation(this.ddBandB_sel);
                    }
                    else this.RemoveBorderValidation(this.ddBandB_sel);
                    break;
                case this.ddBandC_sel:
                    if (bandA_val === null || bandA_val === '') {
                        errmsg += "Color selection required for Band A<br/>";
                        this.AddBorderValidation(this.ddBandA_sel);
                    }
                    if (bandB_val === null || bandB_val === '') {
                        errmsg += "Color selection required for Band B<br/>";
                        this.AddBorderValidation(this.ddBandB_sel);
                    }
                    if (dropdown.value === null || dropdown.value === '') {
                        errmsg += "Color selection required for Band C<br/>";
                        this.AddBorderValidation(this.ddBandC_sel);
                    }
                    else this.RemoveBorderValidation(this.ddBandC_sel);
                    break;
                case this.ddBandD_sel:
                    if (bandA_val === null || bandA_val === '') {
                        errmsg += "Color selection required for Band A<br/>";
                        this.AddBorderValidation(this.ddBandA_sel);
                    }
                    if (bandB_val === null || bandB_val === '') {
                        errmsg += "Color selection required for Band B<br/>";
                        this.AddBorderValidation(this.ddBandB_sel);
                    }
                    if (bandC_val === null || bandC_val === '') {
                        errmsg += "Color selection required for Band C<br/>";
                        this.AddBorderValidation(this.ddBandC_sel);
                    }
                    break;
                default:
                    if (bandA_val === null || bandA_val === '') {
                        errmsg += "Color selection required for Band A<br/>";
                        this.AddBorderValidation(this.ddBandA_sel);
                    }
                    if (bandB_val === null || bandB_val === '') {
                        errmsg += "Color selection required for Band B<br/>";
                        this.AddBorderValidation(this.ddBandB_sel);
                    }
                    if (bandC_val === null || bandC_val === '') {
                        errmsg += "Color selection required for Band C<br/>";
                        this.AddBorderValidation(this.ddBandC_sel);
                    }
                    break;
            }
        } else {
            if (bandA_val === null || bandA_val === '') {
                errmsg += "Color selection required for Band A<br/>";
                this.AddBorderValidation(this.ddBandA_sel);
            }
            if (bandB_val === null || bandB_val === '') {
                errmsg += "Color selection required for Band B<br/>";
                this.AddBorderValidation(this.ddBandB_sel);
            }
            if (bandC_val === null || bandC_val === '') {
                errmsg += "Color selection required for Band C<br/>";
                this.AddBorderValidation(this.ddBandC_sel);
            }
        }

        if (errmsg === '') {
            $(this.ohmCalculateValidationMessage_sel).fadeOut();
        }
        else {
            $(this.ohmCalculateValidationMessage_sel).fadeIn();
        }
        $(this.ohmCalculateValidationMessage_sel).html(errmsg);
    },

    Init: function () {
        this.SetDropdownsClass();
        this.SetupHandlers();
        this.EnableTooltips();
    },

    SetDropdownsClass: function () {
        $('select').addClass('field_dropdown');
    },

    SetupHandlers: function () {
        $(this.btnReset_sel).click(function () {
            ctrl.ResetInputs();
        });
        $(this.btnCalculate_sel).click(function () {
            ctrl.CalculateOhmValue();
        });
        $('select').on('change', function () { ctrl.DropDownSelectionChange(this); })
    },

    EnableTooltips: function () {
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
    }
}

var ctrl = OhmCalc.controller;
ctrl.Init();