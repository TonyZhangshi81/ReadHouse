var RHF = RHF || {};

RHF.Login = RHF.Login || (function () {
	/* 圖片滾動特效腳本 */
	imageProgramaDisplay = function () {
		$(".tagItem").each(function (i, target) {
			/* 光標移入 */
			$(target).mouseenter(function (e) {
				$(target).stop();
				$(target).parent().addClass("curr");
				$(".tagItem").not($(target)).addClass("not_curr");
				$(target).attr("style", "z-index: 9999;");
				if ((i + 1) % 10 > 5 || (i + 1) % 10 == 0) {
					$(target).animate({
						width: "150px",
						height: "230px",
						top: "-60px",
						left: "-55px"
					}, "normal");
				} else {
					$(target).animate({
						width: "150px",
						height: "230px",
						top: "-60px",
						left: "-5px"
					}, "normal");
				}
			});
			/* 光標移出 */
			$(target).mouseleave(function (e) {
				$(target).stop();
				$(target).parent().removeClass("curr");
				$(".tagItem").not(target).removeClass("not_curr");
				$(target).removeAttr("style");
				$(target).animate({
					width: "90px",
					height: "150px",
					top: "0",
					left: "0"
				}, "normal");
			});
		})
	};

	return {
		imageProgramaDisplay: imageProgramaDisplay
	};

}());