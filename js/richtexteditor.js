(function () {

    function showToolbar(editor) {
        var toolbar = $('<div></div>');
        toolbar.append($('<button type="button" onclick="document.execCommand(\'bold\',false,null)" style=""><img src="images/tango/22x22/actions/format-text-bold.png"/></button>'));
        toolbar.append($('<button type="button" onclick="document.execCommand(\'italic\',false,null)" style=""><img src="images/tango/22x22/actions/format-text-italic.png"/></button>'));
        toolbar.append($('<button type="button" onclick="document.execCommand(\'undo\',false,null)"><img src="images/tango/22x22/actions/edit-undo.png"/></button>'));
        toolbar.append($('<button type="button" onclick="document.execCommand(\'redo\',false,null)"><img src="images/tango/22x22/actions/edit-redo.png"/></button>'));
        toolbar.insertBefore(editor);
    }

    $(document).on('create', '[contenteditable]', function () {
        showToolbar(this);
    });
    $('[contenteditable]').each(function () {
        showToolbar(this);
    });
    
    $(document).on('focus', '[contenteditable]', function () {
        var $this = $(this);
        $this.data('before', $this.html());
        return $this;
    }).on('blur keyup paste', '[contenteditable]', function () {
        var $this = $(this);
        if ($this.data('before') !== $this.html()) {
            $this.data('before', $this.html());
            $this.trigger('change');
        }
        return $this;
    }).on('blur', '[contenteditable]', function () {
        var $this = $(this);
        if ($this.data('before') !== $this.html()) {
            $this.data('before', $this.html());
            $this.trigger('blur');
        }
        return $this;
    });
    
})();
