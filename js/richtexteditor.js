(function () {
    $(document).on('focus', '[contenteditable]', function () {
        var $this = $(this);
        $this.data('before', $this.html());
        return $this;
    }).on('blur', '[contenteditable]', function () {
        var $this = $(this);
        if ($this.data('before') !== $this.html()) {
            $this.data('before', $this.html());
            console.log('trigger change');
            $this.trigger('change');
        }
        return $this;
    });
})();


function ContentEditor() {
    var self = this;
    this.executeCommand = function (command, toolbarEvent) {
        if (!document.queryCommandEnabled(command)) {
            return;
        }
        document.execCommand(command, false, null);
        $('[contenteditable]').trigger('change'); 
    }

    this.formatBold = function (model, event) {
        self.executeCommand('bold', event);
    }

    this.formatItalic = function (model, event) {
        self.executeCommand('italic', event);
    }

    this.undo = function (model, event) {
        self.executeCommand('undo', event);
    }

    this.redo = function (model, event) {
        self.executeCommand('redo', event);
    }
};

var contentEditor = new ContentEditor();
