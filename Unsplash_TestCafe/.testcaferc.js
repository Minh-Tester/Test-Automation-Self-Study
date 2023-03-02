const constant = require('../Unsplash_TestCafe/test/data/Constant.json');

module.exports = {
    hooks: {       
        test: {
            before: async t => {
                await t.maximizeWindow()
                
            }
        },
    }, 
    baseUrl: constant.baseUrl,
    browsers: "chrome",
    src: "test",
    reporter: "list",
    screenshots: {
        path: "artifacts/screenshots",
        takeOnFails: true,
        fullPage: true,
        pathPattern:
            "${DATE}_${TIME}/test-${TEST_INDEX}/${USERAGENT}/${FILE_INDEX}.png"
    },
    videoPath: "artifacts/videos",
        videoOptions: {
        singleFile: true,
        failedOnly: true,
    },
    concurrency: 1,
    selectorTimeout: 30000,
    assertionTimeout: 30000,
    pageLoadTimeout: 30000,
    speed: 1,
    skipJsErrors: true
}