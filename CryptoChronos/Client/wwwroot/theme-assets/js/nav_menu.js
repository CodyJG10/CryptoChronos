// menu popup
function initNavMenu() {
	let header = $('.js-header');
	let popup = header.find('.menu__popup');
	let icon = header.find('.has_popup');

	icon.on('click', function (e) {
		e.stopPropagation();
		popup.toggleClass('visible');
	});
	$(document).on('click', 'body', function (e) {
		if (!$(e.target).is('.visible'))
			popup.removeClass('visible');
	})
}