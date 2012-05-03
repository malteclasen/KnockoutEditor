(function () {

    function showToolbar(editor) {
        var toolbar = $('<div></div>');
        toolbar.append($('<button type="button" onclick="document.execCommand(\'bold\',false,null)" style=""><img src="images/tango/22x22/actions/format-text-bold.png"/></button>'));
        toolbar.append($('<button type="button" onclick="document.execCommand(\'italic\',false,null)" style=""><img src="images/tango/22x22/actions/format-text-italic.png"/></button>'));
        toolbar.append($('<button type="button" onclick="document.execCommand(\'undo\',false,null)"><img src="images/tango/22x22/actions/edit-undo.png"/></button>'));
        toolbar.append($('<button type="button" onclick="document.execCommand(\'redo\',false,null)"><img src="images/tango/22x22/actions/edit-redo.png"/></button>'));
        toolbar.insertBefore(editor);
        /*
        var b = $('<input type="button">');
        b.appendTo(toolbar);
        //b.attr({ onclick: "alert('y');" });
        b[0].onclick = function () { alert('z'); };
        b.text("button");
        b.on('click', function () { alert('x'); })
        b.click();
        //alert($(b[0]).html());
        //alert(b.parent().children().last().html());
        */
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
    }).on('blur', '[contenteditable]', function () {
        var $this = $(this);
        if ($this.data('before') !== $this.html()) {
            $this.data('before', $this.html());
            $this.trigger('change');
        }
        return $this;
    });
})();
