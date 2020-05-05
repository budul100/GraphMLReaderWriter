@echo off

pushd %1

git rm -r --cached .
git add .
git commit -m "fixed untracked files"

popd