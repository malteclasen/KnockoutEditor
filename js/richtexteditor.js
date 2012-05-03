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
