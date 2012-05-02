(function () {

    function showToolbar(editor) {
        var toolbar = $('<div>Toolbar</div>');
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
