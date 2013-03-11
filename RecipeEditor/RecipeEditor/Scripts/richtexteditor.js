(function () {
    $(document).on('focus', '[contenteditable]', function () {
        var $this = $(this);
        $this.data('before', $this.html());
        return $this;
    }).on('blur', '[contenteditable]', function () {
        var $this = $(this);
        if ($this.data('before') !== $this.html()) {
            $this.data('before', $this.html());
            $this.trigger('change');
        }
        return $this;
    });
})();


function ContentEditor() {
    var self = this;
    this.executeCommand = function(command, toolbarEvent) {
        if (!document.queryCommandEnabled(command)) {
            return;
        }
        document.execCommand(command, false, null);
        $('[contenteditable]').trigger('change');
    };

    this.formatBold = function(model, event) {
        self.executeCommand('bold', event);
    };

    this.formatItalic = function(model, event) {
        self.executeCommand('italic', event);
    };

    this.cleanUp = function(element) {

    };
};

var contentEditor = new ContentEditor();
