---
layout: post
date: 2019-12-05
---
 
 # How to create a Python package 

This recipe describes how to create a package containing executable code.  

<!--more-->

## Set up

### Prepare your source code

Create a __main__.py file

It should only contain an import of your code, and then a call to the main method you have there.

Example:

```python
import listgits

listgits.main()
```


### Create a setup.py file

Copy from [Packaging Python Projects](https://packaging.python.org/tutorials/packaging-projects/)

Replace where appropriate with your own settings

```python
import setuptools

with open("README.md", "r") as fh:
    long_description = fh.read()

setuptools.setup(
    name="example-pkg-YOUR-USERNAME-HERE", # Replace with your own username
    version="0.0.1",
    author="Example Author",
    author_email="author@example.com",
    description="A small example package",
    long_description=long_description,
    long_description_content_type="text/markdown",
    url="https://github.com/pypa/sampleproject",
    packages=setuptools.find_packages(),
    classifiers=[
        "Programming Language :: Python :: 3",
        "License :: OSI Approved :: MIT License",
        "Operating System :: OS Independent",
    ],
    python_requires='>=3.6',
)
```

Note that the name only need to be like this for the test package. When you're ready to release to production, replace with only the package name itself.

### Add an empty  __init__.py file

Create a folder named  <your_package_name>_pkg

Add an empty file named __init__.py

[See information](https://packaging.python.org/tutorials/packaging-projects/#a-simple-project9)

##  Create accounts

You need accounts at [test.pypi](https://test.pypi.org/account/register/) and the [real site](https://pypi.org/)

## Create package and upload

### Ensure that the following folders are not existing

builds

dist

*.egg-info

If these folders do exist, you can't update to a new version

### Create the package

```
python setup.py sdist bdist_wheel
```


### Upload the package to test

```
python -m twine upload --repository-url https://test.pypi.org/legacy/ dist/*
```

You will be asked for your credentials to test.pypi

### Upload the package to production

```
python -m twine upload dist/*
```


### Test your uploaded package

It will take a few seconds for the package to register after your upload.  Watch the version number when you install:

```
pip install --index-url https://test.pypi.org/simple/ --no-deps <yourpackagename>   --user -U
```

Run the tool

```
yourtoolname
```

### Enable the tool as git command aliases

In your default .gitconfig file, add the following lines to the section under [Alias].  If it doesnt exist, create it.

```
listgits = !python listgits $@
lg = !git listgits $@
```
This mean you can call the commands as either the fullname:

```
git listgits
```
or even as a short command

```
git lg
```

### Statistics for the package

[PyPiStats](https://pypistats.org/)
