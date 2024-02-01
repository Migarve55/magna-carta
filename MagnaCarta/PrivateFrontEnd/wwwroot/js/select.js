function setupMultiSelect(element) {
    $(element).select2({
        theme: "bootstrap-5",
        width: "100%",
        placeholder: $(this).data('placeholder'),
        closeOnSelect: false,
    });   
}

function getSelectedValues(element) {
    const result = [];
    for (const option of element.selectedOptions) {
        result.push(parseInt(option.value));
    }
    return result;
}